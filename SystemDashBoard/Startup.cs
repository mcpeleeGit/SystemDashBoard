using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemDashBoard.Startup))]
namespace SystemDashBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
