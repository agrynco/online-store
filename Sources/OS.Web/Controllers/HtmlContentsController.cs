using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Controllers.Administration;
using OS.Web.Models.HtmlContentViewModels;

namespace OS.Web.Controllers
{
    public class HtmlContentsController : BaseAdminController
    {
        private readonly HtmlContentsBL _htmlContentsBL;

        public HtmlContentsController(HtmlContentsBL htmlContentsBL)
        {
            _htmlContentsBL = htmlContentsBL;
        }

        public ActionResult Edit(HtmlContentCode htmlContentCode)
        {
            HtmlContentCreateOrEditViewModel model;

            HtmlContent htmlContent = _htmlContentsBL.GetByCode(htmlContentCode);

            if (htmlContent != null)
            {
                model = new HtmlContentCreateOrEditViewModel
                    {
                        Text = htmlContent.Text,
                        Code = htmlContent.Code,
                        Id = htmlContent.Id == 0 ? (int?) null : htmlContent.Id
                    };
            }
            else
            {
                model = new HtmlContentCreateOrEditViewModel
                    {
                        Code = htmlContentCode
                    };
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(HtmlContentCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                HtmlContent htmlContent;
                if (model.Id.HasValue)
                {
                    htmlContent = _htmlContentsBL.GetById(model.Id.Value);
                }
                else
                {
                    htmlContent = new HtmlContent();
                }

                htmlContent.Code = model.Code;
                htmlContent.Text = model.Text;
                _htmlContentsBL.Update(htmlContent);

                model.Id = htmlContent.Id;
            }

            ModelState.Clear();
            return View("Edit", model);
        }
    }
}