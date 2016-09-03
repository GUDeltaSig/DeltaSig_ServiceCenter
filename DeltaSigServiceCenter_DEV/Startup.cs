using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeltaSigServiceCenter_DEV.Startup))]
namespace DeltaSigServiceCenter_DEV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
