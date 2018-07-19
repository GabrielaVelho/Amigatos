using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoAmigatos.Startup))]
namespace ProjetoAmigatos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
