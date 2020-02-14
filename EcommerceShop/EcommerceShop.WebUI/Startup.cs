using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcommerceShop.WebUI.Startup))]
namespace EcommerceShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
