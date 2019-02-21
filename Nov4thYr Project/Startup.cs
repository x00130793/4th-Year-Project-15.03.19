using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nov4thYr_Project.Startup))]
namespace Nov4thYr_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
