using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GassoCo.Startup))]
namespace GassoCo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
