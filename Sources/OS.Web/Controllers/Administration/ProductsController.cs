using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSiteMapProvider.Web.Mvc.Filters;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Business.Logic.Exceptions;
using OS.Web.Models.ProductViewModels;

namespace OS.Web.Controllers.Administration
{
    public class ProductsController : BaseAdminController
    {
        private readonly BrandsBL _brandsBL;
        private readonly ContentContentTypesBL _contentContentTypesBL;
        private readonly CountriesBL _countriesBL;
        private readonly CurrenciesBL _currenciesBL;
        private readonly ProductCategoriesBL _productCategoriesBL;
        private readonly ProductPhotosBL _productPhotosBL;
        private readonly ProductsBL _productsBL;

        public ProductsController(ProductCategoriesBL productCategoriesBL,
            ProductsBL productsBL, BrandsBL brandsBL, CountriesBL countriesBL,
            ContentContentTypesBL contentContentTypesBL, ProductPhotosBL productPhotosBL,
            CurrenciesBL currenciesBL)
        {
            _productCategoriesBL = productCategoriesBL;
            _productsBL = productsBL;
            _brandsBL = brandsBL;
            _countriesBL = countriesBL;
            _contentContentTypesBL = contentContentTypesBL;
            _productPhotosBL = productPhotosBL;
            _currenciesBL = currenciesBL;
        }

        public ActionResult Index(ProductsFilterViewModel filter)
        {
            if (TempData[Constants.TempDataKeys.PRODUCTS_FILTER_VIEW_MODEL] != null)
            {
                filter = (ProductsFilterViewModel) TempData[Constants.TempDataKeys.PRODUCTS_FILTER_VIEW_MODEL];
            }

            ProductsViewModel model = new ProductsViewModel
                {
                    Filter = filter
                };

            if (ModelState.IsValid)
            {
                ModelState.RemoveStateFor(filter, viewModel => filter.Category.Name);
                if (filter.Category.Id.HasValue)
                {
                    filter.Category.Name = _productCategoriesBL.GetById(filter.Category.Id.Value).Name;
                }

                ProductsFilter productsFilter = new ProductsFilter
                    {
                        ParentId = filter.Category.Id
                    };
                productsFilter.PaginationFilter.PageNumber = filter.PageNumber;
                productsFilter.PaginationFilter.PageSize = filter.PageSize;

                PagedProductListResult pagedProductListResult = _productsBL.Get(productsFilter);

                model.Products = pagedProductListResult.Entities.Select(entity => new ProductListItemViewModel
                    {
                        Product = entity,
                        CategoryId = filter.Category.Id
                    }).ToList();
            }

            return View(model);
        }

        [SiteMapCacheRelease]
        public ActionResult Delete(int id, int? categoryid)
        {
            _productsBL.Delete(id);

            ProductsFilterViewModel filterViewModel = new ProductsFilterViewModel();
            filterViewModel.Category.Id = categoryid;
            TempData[Constants.TempDataKeys.PRODUCTS_FILTER_VIEW_MODEL] = filterViewModel;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [SiteMapCacheRelease]
        public ActionResult Create(int? categoryId)
        {
            ProductCreateOrEditViewModel model = new ProductCreateOrEditViewModel(categoryId);

            if (categoryId.HasValue)
            {
                model.CategorySelectorViewModel.Name = _productCategoriesBL.GetById(categoryId.Value).Name;
                model.CategorySelectorViewModel.ParentCategories = _productCategoriesBL.GetParentCategories(categoryId.Value).Select(parentCategory => parentCategory.Name).ToArray();
            }

            return View("Edit", model);
        }

        public ActionResult Edit(int id, int? categoryId)
        {
            Product product = _productsBL.GetById(id);
            if (!categoryId.HasValue)
            {
                categoryId = product.Categories.First().Id;
            }

            ProductCreateOrEditViewModel model = new ProductCreateOrEditViewModel
                {
                    Name = product.Name,
                    ShortDescription = product.ShortDescription,
                    Description = product.Description,
                    Id = product.Id,
                    BrandName = product.Brand.Name,
                    CountryName = product.CountryProducer.Name,
                    Price = product.Price.ToString(),
                    Publish = product.Publish,
                    Code = product.Code,
                    Currencies = _currenciesBL.GetAll(),
                    CurrencyIdOfThePrice = product.CurrencyIdOfThePrice,
                    PriceInTheMainCurrency = product.PriceInTheMainCurrency
                };

            if (product.MetaData != null)
            {
                model.MetaDataViewModel.Author = product.MetaData.Author;
                model.MetaDataViewModel.Copyright = product.MetaData.Copyright;
                model.MetaDataViewModel.Description = product.MetaData.Description;
                model.MetaDataViewModel.Keywords = product.MetaData.Keywords;
            }

            model.CategorySelectorViewModel.Id = categoryId;
            if (categoryId.HasValue)
            {
                model.CategorySelectorViewModel.Name = _productCategoriesBL.GetById(categoryId.Value).Name;
                model.CategorySelectorViewModel.ParentCategories = _productCategoriesBL.GetParentCategories(categoryId.Value).Select(parentCategory => parentCategory.Name).ToArray();
            }

            model.ProductPhotoViewModels.AddRange(product.Photos.Where(photo => !photo.IsDeleted).Select(photo => new ProductPhotoViewModel
                {
                    Id = photo.Id,
                    FileName = photo.FileName,
                    IsMain = photo.IsMain
                }));

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [SiteMapCacheRelease]
        public ActionResult Save(ProductCreateOrEditViewModel model)
        {
            if (!model.CategorySelectorViewModel.Id.HasValue)
            {
                ModelState.AddModelError("CategorySelectorViewModel.Name", "Вказана неіснуюча категорія");
            }

            Product alreadyExistedProduct = _productsBL.GetByName(model.Name);

            if (alreadyExistedProduct != null && model.Id.HasValue && model.Id.Value != alreadyExistedProduct.Id)
            {
                if (!alreadyExistedProduct.IsDeleted)
                {
                    ModelState.AddModelError("Name", "Продукт з таким іменем вже існує");
                }
            }

            if (ModelState.IsValid)
            {
                if (alreadyExistedProduct != null && model.Id.HasValue && model.Id.Value != alreadyExistedProduct.Id)
                {
                    if (alreadyExistedProduct.IsDeleted)
                    {
                        _productsBL.DeletePermanently(alreadyExistedProduct.Id);
                    }
                }

                Product target = GetProductToBeSaved(model);

                Product byCode = _productsBL.GetByCode(model.Code);

                if (byCode != null && byCode.Id != target.Id)
                {
                    ModelState.AddModelError("Code", "Введений код належить іншому продукту");
                    return View("Edit", model);
                }

                target.Categories.Clear();
                target.Categories.Add(_productCategoriesBL.GetById(model.CategorySelectorViewModel.Id.Value));

                target.Name = model.Name;
                target.Description = model.Description;
                target.ShortDescription = model.ShortDescription;
                decimal price = decimal.Parse(model.Price);
                target.Price = price;
                target.Publish = model.Publish;
                target.Code = model.Code;
                target.PriceInTheMainCurrency = _productsBL.CalculatePriceInTheMainCurrency(model.CurrencyIdOfThePrice.Value, price);
                target.CurrencyIdOfThePrice = model.CurrencyIdOfThePrice.Value;

                ProcessBrand(model, target);
                ProcessCountry(model, target);
                ProcessPhotos(model, target);
                ProcessMetadata(model.MetaDataViewModel, target);

                if (target.Id == 0)
                {
                    _productsBL.Create(target);
                }
                else
                {
                    _productsBL.Update(target);
                }

                if (ModelState.IsValid)
                {
                    TempData[Constants.TempDataKeys.PRODUCTS_FILTER_VIEW_MODEL] = new ProductsFilterViewModel(model.CategorySelectorViewModel.Id.Value);
                    return RedirectToAction("Index");
                }
            }
            if (model.CategorySelectorViewModel.Id.HasValue)
            {
                model.CategorySelectorViewModel.ParentCategories =
                    _productCategoriesBL.GetParentCategories(model.CategorySelectorViewModel.Id.Value).Select(parentCategory => parentCategory.Name).ToArray();
            }

            return View("Edit", model);
        }

        private void ProcessMetadata(ProductMetaDataViewModel metaDataViewModel, Product target)
        {
            if (!string.IsNullOrEmpty(metaDataViewModel.Author) ||
                !string.IsNullOrEmpty(metaDataViewModel.Copyright) ||
                !string.IsNullOrEmpty(metaDataViewModel.Description) ||
                !string.IsNullOrEmpty(metaDataViewModel.Keywords))
            {
                if (target.MetaData == null)
                {
                    target.MetaData = new ProductMetaData();
                }

                target.MetaData.Author = metaDataViewModel.Author;
                target.MetaData.Copyright = metaDataViewModel.Copyright;
                target.MetaData.Description = metaDataViewModel.Description;
                target.MetaData.Keywords = metaDataViewModel.Keywords;
            }
            else
            {
                target.MetaData = null;
            }
        }

        private Product GetProductToBeSaved(ProductCreateOrEditViewModel model)
        {
            Product target;
            if (model.Id.HasValue)
            {
                target = _productsBL.GetById(model.Id.Value);

                _productPhotosBL.Delete(model.ProductPhotoViewModels.Where(x => x.IsDeleted).Select(x => x.Id).ToArray());
            }
            else
            {
                target = new Product();
                ProductCategory owner = _productCategoriesBL.GetById(model.CategorySelectorViewModel.Id.Value);
                _productCategoriesBL.Add(target, owner);
            }
            return target;
        }

        private void ProcessBrand(ProductCreateOrEditViewModel model, Product target)
        {
            if (!string.IsNullOrEmpty(model.BrandName))
            {
                try
                {
                    Brand existedBrand = _brandsBL.GetByName(model.BrandName);
                    target.BrandId = existedBrand.Id;
                }
                catch (ThereIsNoBrandWithNameException)
                {
                    ModelState.AddModelError("BrandName", $"Бренд з ім'ям '{model.BrandName}' не існує");
                }
            }
        }

        private void ProcessCountry(ProductCreateOrEditViewModel model, Product target)
        {
            if (!string.IsNullOrEmpty(model.CountryName))
            {
                try
                {
                    Country existedCountry = _countriesBL.GetByName(model.CountryName);
                    target.CountryProducer = existedCountry;
                }
                catch (ThereIsNoCountryWithNameException)
                {
                    ModelState.AddModelError("CountryName", string.Format("Країна з ім'ям '{0}' не існує", model.CountryName));
                }
            }
        }

        private void ProcessPhotos(ProductCreateOrEditViewModel model, Product target)
        {
            ProductPhotoViewModel mainPhotoViewModel = model.ProductPhotoViewModels.SingleOrDefault(x => x.IsMain);
            target.Photos.ForEach(photo => { photo.IsMain = mainPhotoViewModel != null && photo.Id == mainPhotoViewModel.Id; });

            foreach (HttpPostedFileBase postedFile in model.PostedProductPhotos)
            {
                if (postedFile != null)
                {
                    ProductPhoto productPhoto = new ProductPhoto
                        {
                            Data = new byte[postedFile.InputStream.Length],
                            ContentContentType = _contentContentTypesBL.Get(postedFile.ContentType),
                            FileName = postedFile.FileName,
                            IsMain = false
                        };

                    postedFile.InputStream.Read(productPhoto.Data, 0, productPhoto.Data.Length);

                    target.Photos.Add(productPhoto);
                }
            }
        }
    }
}