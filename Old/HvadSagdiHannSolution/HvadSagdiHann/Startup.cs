using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HvadSagdiHann.Startup))]
namespace HvadSagdiHann
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
