using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ensalamento.Web.UI.Startup))]
namespace Ensalamento.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
