using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoPark.Startup))]
namespace AutoPark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
