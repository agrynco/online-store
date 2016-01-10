#region Usings
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using OS.Business.Domain;
using OS.Business.Logic;
#endregion

namespace OS.Web
{
    // Configure the application user manager used in this application. usersBL is defined in ASP.NET Identity and is used by the application.

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(UsersBL usersBL, IAuthenticationManager authenticationManager)
            : base(usersBL, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return ((UsersBL)UserManager).CreateUserIdentityAsync(user);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<UsersBL>(), context.Authentication);
        }
    }
}