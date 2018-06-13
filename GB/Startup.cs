using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GB.Startup))]
namespace GB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
