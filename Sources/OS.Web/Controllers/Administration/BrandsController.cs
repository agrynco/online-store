using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models.BrandViewModels;

namespace OS.Web.Controllers.Administration
{
    public class BrandsController : BaseAdminController
    {
        private readonly BrandsBL _brandsBL;

        public BrandsController(BrandsBL brandsBL)
        {
            _brandsBL = brandsBL;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Brand brand = _brandsBL.GetById(id);
            BrandCreateOrEditViewModel model = new BrandCreateOrEditViewModel
                {
                    Id = brand.Id,
                    Name = brand.Name
                };

            return View(model);
        }

        public ActionResult Create()
        {
            return View("Edit", new BrandCreateOrEditViewModel());
        }

        public ActionResult Save(BrandCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Brand target;

                if (model.Id.HasValue)
                {
                    target = _brandsBL.GetById(model.Id.Value);
                }
                else
                {
                    target = new Brand();
                }

                target.Name = model.Name;

                if (model.Id.HasValue)
                {
                    _brandsBL.Update(target);
                }
                else
                {
                    _brandsBL.Add(target);
                }
                return RedirectToAction("Index");
            }

            return View("Edit", model);}
    }
}