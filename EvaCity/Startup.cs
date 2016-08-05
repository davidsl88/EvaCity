using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EvaCity.Startup))]
namespace EvaCity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
