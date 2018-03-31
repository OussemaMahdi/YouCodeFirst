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
    public interface IDocumentRepository : IRepository<Document, int>
    {
        bool IsDocumentExists(int id);
        IList<DocumentDisplayViewModel> DocumentDisplay(WebSiteDBContext context);
        Document getDocumentById(WebSiteDBContext context, int id);
    }

}