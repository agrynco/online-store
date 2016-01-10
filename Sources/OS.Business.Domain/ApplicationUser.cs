﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace OS.Business.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public Person Person { get; set; }
    }
}