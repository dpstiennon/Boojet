using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Boojet.Startup))]
namespace Boojet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
