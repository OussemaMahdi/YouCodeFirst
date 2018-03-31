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
    public interface IApplicationRepository : IRepository<Application, int>
    {
        bool IsApplicationExists(int id);
        IList<ApplicationDisplayViewModel> ApplicationDisplay(WebSiteDBContext context);

        Application getApplicationById(WebSiteDBContext context, int id);
        IList<OperationDisplayViewModel> ApplicationOperationsDisplay(WebSiteDBContext context, int applicationId);
        bool AutorizeToClient(WebSiteDBContext context, int applicationId, string clientId);
    }

}