using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Subtitles.Startup))]
namespace Subtitles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
