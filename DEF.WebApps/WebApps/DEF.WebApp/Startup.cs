using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DEF.WebApp.Startup))]
namespace DEF.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
