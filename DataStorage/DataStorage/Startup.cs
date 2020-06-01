using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataStorage.Startup))]
namespace DataStorage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
