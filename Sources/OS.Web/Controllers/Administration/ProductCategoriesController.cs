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
        private readonly ProductCategoriesBL _productCategoriesBL;
        private readonly ProductsBL _productsBL;
        private readonly BrandsBL _brandsBL;
        private readonly CountriesBL _countriesBL;

        public ProductCategoriesController(ProductCategoriesBL productCategoriesBL, ProductsBL productsBL,
            BrandsBL brandsBL, CountriesBL countriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
            _productsBL = productsBL;
            _brandsBL = brandsBL;
            _countriesBL = countriesBL;
        }

        public ActionResult Index(int? parentId)
        {
            ProductCategoriesViewModel viewModel = new ProductCategoriesViewModel
                {
                    ProductCategories = _productCategoriesBL.GetCategories(parentId),
                    ProductsFromLevelUpProductCategory = parentId.HasValue ? _productCategoriesBL.GetProducts(parentId.Value).Select(product => new ProductListItemViewModel
                        {
                            ParentCategoryId = parentId.Value,
                            Product = product
                        }).ToList() : new List<ProductListItemViewModel>()
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

        [HttpGet]
        public ActionResult CreateProduct(int categoryId)
        {
            ProductCreateOrEditViewModel model = new ProductCreateOrEditViewModel
                {
                    Product = new Product(),
                    ParentCategoryId = categoryId,
                    PostedProductPhotos = new List<HttpPostedFileBase>(new HttpPostedFileBase[5])
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
                        ModelState.AddModelError("CountryName", $"Країна ім'ям '{model.CountryName}' не існує");
                    }
                }

                ProductCategory owner = _productCategoriesBL.GetById(model.ParentCategoryId);

                foreach (HttpPostedFileBase postedFile in model.PostedProductPhotos)
                {
                    if (postedFile != null)
                    {
                        ProductPhoto productPhoto = new ProductPhoto
                            {
                                Content = new byte[postedFile.InputStream.Length],
                                ContentType = postedFile.ContentType,
                                FileName = postedFile.FileName
                        };

                        postedFile.InputStream.Read(productPhoto.Content, 0, productPhoto.Content.Length);

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
                            parentId = model.ParentCategoryId
                    });
                }
            }

            return View("ProductEdit", model);
        }
    }
}