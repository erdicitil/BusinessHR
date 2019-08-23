using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessHR.Admin.Startup))]
namespace BusinessHR.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
