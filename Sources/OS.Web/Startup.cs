using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OS.Web.Startup))]
namespace OS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
