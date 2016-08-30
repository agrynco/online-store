#region Usings
using Microsoft.Owin;
using OS.Web;
using Owin;
#endregion

[assembly: OwinStartup(typeof(Startup))]

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