using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperHeroCreator.Startup))]
namespace SuperHeroCreator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
