using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Csn.OrmEdd4a.App.Startup))]
namespace Csn.OrmEdd4a.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
