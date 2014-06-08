using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReactionGif.Startup))]
namespace ReactionGif
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
