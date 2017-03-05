using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomError.Startup))]
namespace CustomError
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
