using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAffablebean.Startup))]
namespace MvcAffablebean
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
