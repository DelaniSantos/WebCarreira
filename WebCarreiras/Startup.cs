using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCarreiras.Startup))]
namespace WebCarreiras
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
