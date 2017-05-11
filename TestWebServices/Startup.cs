using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestWebServices.Startup))]
namespace TestWebServices
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
