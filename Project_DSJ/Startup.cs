using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_DSJ.Startup))]
namespace Project_DSJ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
