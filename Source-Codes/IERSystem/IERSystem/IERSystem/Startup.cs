using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IERSystem.Startup))]
namespace IERSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
