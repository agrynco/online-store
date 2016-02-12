﻿using System.Linq;
using System.Web;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Business.Logic.Exceptions;
using OS.Web.Models.ProductViewModels;

namespace OS.Web.Controllers.Administration
{
    public class ProductsController : BaseAdminController
    {
        private readonly ProductCategoriesBL _productCategoriesBL;
        private readonly ProductsBL _productsBL;
        private readonly BrandsBL _brandsBL;
        private readonly CountriesBL _countriesBL;
        private readonly ContentContentTypesBL _contentContentTypesBL;

        public ProductsController(ProductCategoriesBL productCategoriesBL,
            ProductsBL productsBL, BrandsBL brandsBL, CountriesBL countriesBL,
            ContentContentTypesBL contentContentTypesBL)
        {
            _productCategoriesBL = productCategoriesBL;
            _productsBL = productsBL;
            _brandsBL = brandsBL;
            _countriesBL = countriesBL;
            _contentContentTypesBL = contentContentTypesBL;
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

                PagedProductListResult pagedProductListResult = _productsBL.Search(productsFilter);

                model.Products = pagedProductListResult.Entities.Select(entity => new ProductListItemViewModel
                    {
                        Product = entity,
                        CategoryId = filter.Category.Id
                    }).ToList();
            }

            return View(model);
        }

        public ActionResult Delete(int id, int? categoryid)
        {
            _productsBL.Delete(id);

            ProductsFilterViewModel filterViewModel = new ProductsFilterViewModel();
            filterViewModel.Category.Id = categoryid;
            TempData[Constants.TempDataKeys.PRODUCTS_FILTER_VIEW_MODEL] = filterViewModel;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id, int? categoryId)
        {
            Product product = _productsBL.GetById(id);

            ProductCreateOrEditViewModel model = new ProductCreateOrEditViewModel
                {
                    Name = product.Name,
                    Description = product.Description,
                    Product = product,
                    Id = product.Id,
                    BrandName = product.Brand.Name,
                    CountryName = product.CountryProducer.Name,
                    OwnerCategoryId = categoryId
                };

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(ProductCreateOrEditViewModel model)
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
                        ModelState.AddModelError("CountryName", string.Format("Країна ім'ям '{0}' не існує", model.CountryName));
                    }
                }

                ProductCategory owner = _productCategoriesBL.GetById(model.OwnerCategoryId.Value);

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

            return View("Edit", model);
        }
    }
}