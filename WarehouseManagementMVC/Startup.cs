using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WarehouseManagementMVC.Startup))]
namespace WarehouseManagementMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
