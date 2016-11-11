using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comp229_Assign03.Startup))]
namespace Comp229_Assign03
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
