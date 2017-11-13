using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Newsletter.web.Startup))]
namespace Newsletter.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
