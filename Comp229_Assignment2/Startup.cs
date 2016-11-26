using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comp229_Assignment2.Startup))]
namespace Comp229_Assignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
