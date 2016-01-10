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

//        public static UsersBL Create(IdentityFactoryOptions<UsersBL> options, IOwinContext context)
//        {
//            var manager = new UsersBL(new UserStore<ApplicationUser>(context.Get<EntityFrameworkDbContext>()));
//            // Configure validation logic for usernames
//            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
//                {
//                    AllowOnlyAlphanumericUserNames = false,
//                    RequireUniqueEmail = true
//                };
//
//            // Configure validation logic for passwords
//            manager.PasswordValidator = new PasswordValidator
//                {
//                    RequiredLength = 6,
//                    RequireNonLetterOrDigit = true,
//                    RequireDigit = true,
//                    RequireLowercase = true,
//                    RequireUppercase = true,
//                };
//
//            // Configure user lockout defaults
//            manager.UserLockoutEnabledByDefault = true;
//            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
//            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
//
//            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
//            // You can write your own provider and plug it in here.
//            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
//                {
//                    MessageFormat = "Your security code is {0}"
//                });
//            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
//                {
//                    Subject = "Security Code",
//                    BodyFormat = "Your security code is {0}"
//                });
//            manager.EmailService = new EmailService();
//            manager.SmsService = new SmsService();
//            var dataProtectionProvider = options.DataProtectionProvider;
//            if (dataProtectionProvider != null)
//            {
//                manager.UserTokenProvider =
//                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
//            }
//            return manager;
//        }
    }
}