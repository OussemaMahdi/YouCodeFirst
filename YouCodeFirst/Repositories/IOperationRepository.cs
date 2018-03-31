using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebSite.Repositories.Generic;
using WebSite.ViewModels;
using WebSite.Dal.Models;
using WebSite.Dal.DataBase;

namespace WebSite.Repositories
{
    public interface IOperationRepository : IRepository<Operation, int>
    {
        IList<OperationDisplayViewModel> OperationDisplay(WebSiteDBContext context);
        bool AutorizeToClient(WebSiteDBContext context, int operationId, string clientId);
        IList<DocumentDisplayViewModel> OperationDocumentsDisplay(WebSiteDBContext context, int op);
    }
}