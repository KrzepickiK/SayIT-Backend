using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SayIt_Accounts.Startup))]
namespace SayIt_Accounts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
