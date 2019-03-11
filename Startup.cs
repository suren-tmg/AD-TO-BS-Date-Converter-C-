using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADToBSDateConverter.Startup))]
namespace ADToBSDateConverter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
