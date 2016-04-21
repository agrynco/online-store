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
            HtmlContent htmlContent = _htmlContentsBL.GetByCode(htmlContentCode);
            if (htmlContent == null)
            {
                htmlContent = new HtmlContent
                    {
                        Code = htmlContentCode
                    };
            }

            return View(new HtmlContentCreateOrEditViewModel
                {
                    HtmlContent = htmlContent,
                    Id = htmlContent.Id
                });
        }

        public ActionResult Save(HtmlContentCreateOrEditViewModel model)
        {
            _htmlContentsBL.Update(model.HtmlContent);

            return RedirectToAction("Edit", model.HtmlContent.Code);
        }
    }
}