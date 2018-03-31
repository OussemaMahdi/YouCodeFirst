using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.App_Start;
using WebSite.Dal.DataBase;
using WebSite.Dal.Models.Account;
using Microsoft.AspNet.Identity;
using WebSite.Dal.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebSite.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User == null || User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var userid = User.Identity.GetUserId(); //get current user id
                
               

                WebSiteDBContext context = new WebSiteDBContext();
                Client client = context.Set<Client>()
                .Include("Applications")
                .Where(c => c.Id == userid)
                .FirstOrDefault();

                if (client!=null)
                {
                    return RedirectToAction("Index", "Client");
                }
                else
                {
                    return RedirectToAction("Index", "Administrator");
                }
            }
        }

        

    }
}
