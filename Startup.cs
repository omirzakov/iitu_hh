using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iitu_project_hh.Startup))]
namespace iitu_project_hh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
