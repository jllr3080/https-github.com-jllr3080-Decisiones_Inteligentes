using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCliente.Startup))]
namespace WebCliente
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
