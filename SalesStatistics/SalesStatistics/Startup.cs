using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesStatistics.Startup))]
namespace SalesStatistics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
