using WebSite.Dal.DataBase;
using WebSite.Dal.Models;
using WebSite.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.ViewModels;

namespace WebSite.Repositories
{
    public interface IClientRepository : IRepository<Client, int>
    {
        Client getClientById(WebSiteDBContext context, string id);

        IList<ApplicationDisplayViewModel> getClientApplications(WebSiteDBContext context, string id);

    }

}