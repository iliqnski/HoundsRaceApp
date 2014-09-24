using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HoundsRace.Web.Startup))]
namespace HoundsRace.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
