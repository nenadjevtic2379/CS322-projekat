using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CS322_PZ01.Startup))]
namespace CS322_PZ01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
