using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models;

namespace OS.Web.Controllers.Administration
{
    public class RobotsTxtController : BaseAdminController
    {
        private readonly TextContentsBL _textContentsBL;

        public RobotsTxtController(TextContentsBL textContentsBL)
        {
            _textContentsBL = textContentsBL;
        }

        public ActionResult Edit()
        {
            TextContent textContent = _textContentsBL.Get(TextContentCode.RobotsTxt);

            RobotsTxtCreateOrEditViewModel model = new RobotsTxtCreateOrEditViewModel
                {
                    Text = textContent == null ? string.Empty : textContent.Text,
                    Id = textContent == null ? (int?) null : textContent.Id
                };

            return View(model);
        }

        private void AssignModelToEntity(RobotsTxtCreateOrEditViewModel model, TextContent entity)
        {
            entity.Code = TextContentCode.RobotsTxt;
            entity.Text = model.Text;
        }

        public ActionResult Save(RobotsTxtCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                TextContent textContent;
                if (model.Id.HasValue)
                {
                    textContent = _textContentsBL.Get(TextContentCode.RobotsTxt);
                    AssignModelToEntity(model, textContent);
                    _textContentsBL.Update(textContent);
                }
                else
                {
                    textContent = new TextContent();
                    AssignModelToEntity(model, textContent);
                    textContent = _textContentsBL.Add(textContent);
                }

                model.Id = textContent.Id;
            }

            return View("Edit", model);
        }
    }
}