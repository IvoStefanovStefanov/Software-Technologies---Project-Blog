using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Biliana_Georgieva_Blog.Startup))]
namespace Biliana_Georgieva_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
