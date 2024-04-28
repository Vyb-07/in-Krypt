using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(inKrypt.Startup))]
namespace inKrypt
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
