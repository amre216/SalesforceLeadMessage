using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesForceLeadMessages.Startup))]
namespace SalesForceLeadMessages
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
