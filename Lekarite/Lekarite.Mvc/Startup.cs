using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lekarite.Mvc.Startup))]
namespace Lekarite.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
