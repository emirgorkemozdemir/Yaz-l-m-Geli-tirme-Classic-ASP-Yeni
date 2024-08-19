using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yazılım_Geliştirme_Classic_ASP.Startup))]
namespace Yazılım_Geliştirme_Classic_ASP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
