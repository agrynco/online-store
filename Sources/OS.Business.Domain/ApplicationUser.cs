using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OS.Business.Domain
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        public Person Person { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }

        object IEntity.Id
        {
            get { return Id; }
            set { Id = (string) value; }
        }
    }
}