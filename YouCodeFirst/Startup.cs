using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

using WebSite.Dal.DataBase;
using WebSite.Dal.Models.Account;
using WebSite.App_Start;
using Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.AspNet.Identity.Owin;

[assembly: OwinStartup(typeof(WebSite.Startup))]

namespace WebSite
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(WebSiteDBContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext<RoleManager<ApplicationRole>>((options, context) =>
                new RoleManager<ApplicationRole>(
                    new RoleStore<ApplicationRole>(context.Get<WebSiteDBContext>())));



            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            var _context = new WebSiteDBContext();
            var roleStore = new RoleStore<IdentityRole>(_context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(_context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            //Ajouter le role Administrateur s'il n'existe pas
            var role = roleManager.FindByName(RoleNames.ROLE_ADMINISTRATOR);
            if (role == null)
                roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMINISTRATOR));
            //Ajouter le role Client s'il n'existe pas
            role = roleManager.FindByName(RoleNames.ROLE_CLIENT);
            if (role == null)
                roleManager.Create(new IdentityRole(RoleNames.ROLE_CLIENT));
        }

        public void Configuration(IAppBuilder app)
        {
            // Pour plus d'informations sur la configuration de votre application, visitez https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
        }
    }
}
