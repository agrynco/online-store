#region Usings
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Business.Logic.Exceptions;
using OS.Web.Models.ProductCategoryViewModels;
using OS.Web.Models.ProductViewModels;
#endregion

namespace OS.Web.Controllers.Administration
{
    public class ProductCategoriesController : BaseAdminController
    {
        private readonly BrandsBL _brandsBL;
        private readonly ContentContentTypesBL _contentContentTypesBL;
        private readonly CountriesBL _countriesBL;
        private readonly ProductCategoriesBL _productCategoriesBL;
        private readonly ProductPhotosBL _productPhotosBL;
        private readonly ProductsBL _productsBL;

        public ProductCategoriesController(ProductCategoriesBL productCategoriesBL, ProductsBL productsBL,
            BrandsBL brandsBL, CountriesBL countriesBL, ContentContentTypesBL contentContentTypesBL,
            ProductPhotosBL productPhotosBL)
        {
            _productCategoriesBL = productCategoriesBL;
            _productsBL = productsBL;
            _brandsBL = brandsBL;
            _countriesBL = countriesBL;
            _contentContentTypesBL = contentContentTypesBL;
            _productPhotosBL = productPhotosBL;
        }

        public ActionResult Index(int? parentId)
        {
            ProductCategoriesViewModel viewModel = new ProductCategoriesViewModel
                {
                    ProductCategories = _productCategoriesBL.GetCategories(parentId),
                    ProductsFromLevelUpProductCategory = parentId.HasValue
                        ? _productCategoriesBL.GetProducts(parentId.Value).Select(product => new ProductListItemViewModel
                            {
                                ParentCategoryId = parentId.Value,
                                Product = product
                            }).ToList()
                        : new List<ProductListItemViewModel>()
                };

            if (parentId != null)
            {
                viewModel.LevelUpProductCategory = _productCategoriesBL.GetById(parentId.Value);
            }

            return View(viewModel);
        }

        public ActionResult Delete(int categoryId)
        {
            _productCategoriesBL.Delete(categoryId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create(int? parentId)
        {
            ProductCategoryCreateOrEditViewModel model = new ProductCategoryCreateOrEditViewModel();
            model.ParentId = parentId;
            return View("Edit", model);
        }

        public ActionResult Edit(int categoryId)
        {
            ProductCategory productCategory = _productCategoriesBL.GetById(categoryId);

            ProductCategoryCreateOrEditViewModel model = new ProductCategoryCreateOrEditViewModel
                {
                    Name = productCategory.Name,
                    ParentId = productCategory.ParentId,
                    Id = productCategory.Id
                };

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Save(ProductCategoryCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.Id.HasValue && _productCategoriesBL.GetCategories(model.ParentId).Any(productCategory => productCategory.Name == model.Name))
                {
                    ModelState.AddModelError("Name", "Така категорія вже існує");
                }

                if (ModelState.IsValid)
                {
                    ProductCategory productCategory;

                    if (model.Id.HasValue)
                    {
                        productCategory = _productCategoriesBL.GetById(model.Id.Value);
                        productCategory.Name = model.Name;

                        _productCategoriesBL.Update(productCategory);
                    }
                    else
                    {
                        productCategory = new ProductCategory
                            {
                                ParentId = model.ParentId,
                                Name = model.Name
                            };
                        _productCategoriesBL.Create(productCategory);
                    }

                    return RedirectToAction("Index", new
                        {
                            parentId = model.ParentId
                        });
                }
            }

            return View("Edit", model);
        }

        public ActionResult EditProduct(int productId, int ownerCategoryId)
        {
            Product product = _productsBL.GetById(productId);

            ProductCreateOrEditViewModel model = new ProductCreateOrEditViewModel
                {
                    Product = product,
                    BrandName = product.Brand.Name,
                    CountryName = product.CountryProducer.Name,
                    OwnerCategoryId = ownerCategoryId,
                    ProductPhotoViewModels = product.Photos.Select(photo => new ProductPhotoViewModel
                        {
                            Id = photo.Id,
                            IsDeleted = false,
                            FileName = photo.FileName
                        }).ToList()
                };

            return View("ProductEdit", model);
        }

        [HttpGet]
        public ActionResult CreateProduct(int categoryId)
        {
            ProductCreateOrEditViewModel model = new ProductCreateOrEditViewModel
                {
                    Product = new Product(),
                    OwnerCategoryId = categoryId
                };

            return View("ProductEdit", model);
        }

        public ActionResult DeleteProduct(int productId, int categoryId)
        {
            _productsBL.Delete(productId);

            return RedirectToAction("Index", new
                {
                    parentId = categoryId
                });
        }

        [ValidateInput(false)]
        public ActionResult SaveProduct(ProductCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product target;

                if (model.Id.HasValue)
                {
                    target = _productsBL.GetById(model.Id.Value);

                    DeletePhotos(target, model);
                }
                else
                {
                    target = new Product();
                }

                target.Name = model.Product.Name;
                target.Description = model.Product.Description;

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

                if (!string.IsNullOrEmpty(model.CountryName))
                {
                    try
                    {
                        Country existedCountry = _countriesBL.GetByName(model.CountryName);
                        target.CountryProducer = existedCountry;
                    }
                    catch (ThereIsNoCountryWithNameException)
                    {
                        ModelState.AddModelError("CountryName", string.Format("Країна ім'ям '{0}' не існує", model.CountryName));
                    }
                }

                ProductCategory owner = _productCategoriesBL.GetById(model.OwnerCategoryId);

                foreach (HttpPostedFileBase postedFile in model.PostedProductPhotos)
                {
                    if (postedFile != null)
                    {
                        ProductPhoto productPhoto = new ProductPhoto
                            {
                                Data = new byte[postedFile.InputStream.Length],
                                ContentContentType = _contentContentTypesBL.Get(postedFile.ContentType),
                                FileName = postedFile.FileName
                            };

                        postedFile.InputStream.Read(productPhoto.Data, 0, productPhoto.Data.Length);

                        target.Photos.Add(productPhoto);
                    }
                }

                _productCategoriesBL.Add(target, owner);

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
                    return RedirectToAction("Index", new
                        {
                            parentId = model.OwnerCategoryId
                        });
                }
            }

            return View("ProductEdit", model);
        }

        private void DeletePhotos(Product product, ProductCreateOrEditViewModel model)
        {
            int[] productPhotoIdsToDelete = (from productPhotoViewModel in model.ProductPhotoViewModels
                where productPhotoViewModel.IsDeleted
                select productPhotoViewModel.Id).ToArray();

            _productPhotosBL.Delete(productPhotoIdsToDelete);

            foreach (int photoId in productPhotoIdsToDelete)
            {
                product.Photos.Remove(product.Photos.Single(photo => photo.Id == photoId));
            }
        }
    }
}