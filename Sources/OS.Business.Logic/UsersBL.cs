using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using OS.Business.Domain;

namespace OS.Business.Logic
{
    public class UsersBL : UserManager<ApplicationUser>
    {
        public UsersBL(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public async Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser applicationUser)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await CreateIdentityAsync(applicationUser, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public void CreateUser(string firstName, string lastName, string middleName, string email)
        {
            //IdentityResult result = await UsersBL.CreateAsync(user, model.Password);
            throw new NotImplementedException();
        }
    }
}