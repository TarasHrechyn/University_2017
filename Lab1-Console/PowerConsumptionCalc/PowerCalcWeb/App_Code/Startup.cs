using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PowerCalcWeb.Startup))]
namespace PowerCalcWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
