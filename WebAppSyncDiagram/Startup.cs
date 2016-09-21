using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppSyncDiagram.Startup))]
namespace WebAppSyncDiagram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
