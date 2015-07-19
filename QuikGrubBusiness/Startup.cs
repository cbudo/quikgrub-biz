using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuikGrubBusiness.Startup))]
namespace QuikGrubBusiness
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
