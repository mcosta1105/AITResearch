using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AITResearch.Startup))]
namespace AITResearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
