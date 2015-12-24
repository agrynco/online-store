using System;
using OS.Business.Domain;

namespace OS.Web.Models
{
    public class ContactInfoEditViewModel : BaseCreateOrEditViewModel
    {
        public override int? Id
        {
            get { return ContactInfo == null ? (int?) null : ContactInfo.Id; }
            set
            {
                if (ContactInfo == null)
                {
                    throw new NullReferenceException("Property ContactInfo must be initialized!");    
                }

                ContactInfo.Id = value.Value;
            }
        }

        public ContactInfo ContactInfo { get; set; }
    }
}