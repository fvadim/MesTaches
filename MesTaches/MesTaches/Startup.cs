using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MesTaches.Startup))]
namespace MesTaches
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
