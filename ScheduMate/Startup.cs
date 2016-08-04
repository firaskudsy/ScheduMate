using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScheduMate.Startup))]
namespace ScheduMate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
