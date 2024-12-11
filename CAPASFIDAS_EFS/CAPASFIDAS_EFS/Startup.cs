using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CAPASFIDAS_EFS.Startup))]
namespace CAPASFIDAS_EFS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
