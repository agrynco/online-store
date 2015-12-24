#region Usings
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers.Administration
{
    public abstract class EditController<TCreateOrEditViewModel> : BaseAdminController
        where TCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        public virtual ActionResult Save(TCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                DoSave(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        protected abstract void DoSave(TCreateOrEditViewModel model);
    }

    public class ContactInfoAdminController : EditController<ContactInfoEditViewModel>
    {
        private readonly ContactInfoBL _contactInfoBl;

        public ContactInfoAdminController(ContactInfoBL contactInfoBl)
        {
            _contactInfoBl = contactInfoBl;
        }

        public ActionResult Index()
        {
            return View(_contactInfoBl.Get());
        }

        public ActionResult Edit()
        {
            return View(new ContactInfoEditViewModel {ContactInfo = _contactInfoBl.Get()});
        }

        [ValidateInput(false)]
        public override ActionResult Save(ContactInfoEditViewModel model)
        {
            return base.Save(model);
        }

        protected override void DoSave(ContactInfoEditViewModel model)
        {
            ContactInfo contactInfo = _contactInfoBl.Get();
            contactInfo.Content = model.ContactInfo.Content;

            _contactInfoBl.Update(contactInfo);
        }
    }
}