using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdvertBoard.Startup))]
namespace AdvertBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
