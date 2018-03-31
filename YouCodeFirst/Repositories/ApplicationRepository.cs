using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebSite.Dal.DataBase;
using WebSite.Dal.Models;
using WebSite.Repositories.Generic;
using WebSite.ViewModels;
using System.Collections.ObjectModel;


namespace WebSite.Repositories
{
    public class ApplicationRepository : EntityRepository<WebSiteDBContext, Application, int>, IApplicationRepository
    {
        public ApplicationRepository(WebSiteDBContext context)
            : base(context)
        {
        }

        public bool IsApplicationExists(int id)
        {
            return _context.Applications.
                Any(a => a.ApplicationId == id);
        }

        public Application getApplicationById(WebSiteDBContext context, int id)
        {
            Application a = context.Set<Application>()
                .Where(e => e.ApplicationId == id).FirstOrDefault();
            return a;
        }

        // retourne tous les applications
        public IList<ApplicationDisplayViewModel> ApplicationDisplay(WebSiteDBContext context)
        {
            var data = context.Set<Application>().Include("Operations").ToList();
            IList<ApplicationDisplayViewModel> Display = new List<ApplicationDisplayViewModel>();
            foreach (Application a in data)
            {
                ApplicationDisplayViewModel aux = new ApplicationDisplayViewModel();
                aux.Id = a.ApplicationId;
                aux.Name = a.Name;
                aux.Operations = a.Operations;
                Display.Add(aux);
            }
            return Display;
        }

        // retourne tous les applications
        public IList<OperationDisplayViewModel> ApplicationOperationsDisplay(WebSiteDBContext context, int applicationId)
        {
            Application application = context.Set<Application>()
                .Include("Operations")
                .Where(a => a.ApplicationId == applicationId)
                .FirstOrDefault();

            IList<OperationDisplayViewModel> Display = new List<OperationDisplayViewModel>();

            foreach (Operation op in application.Operations)
            {
                OperationDisplayViewModel aux = new OperationDisplayViewModel();

                aux.OperationId = op.OperationId;
                aux.Name = op.Name;
                aux.Type = op.Type;
                aux.Begin = (DateTime)op.Begin;
                aux.End = (DateTime)op.End;
                Display.Add(aux);
            }

            return Display;
        }

        public bool AutorizeToClient(WebSiteDBContext context, int applicationId, string clientId)
        {
            Application application = context.Set<Application>()
                .Where(a => a.ApplicationId == applicationId)
                .FirstOrDefault();

            Client client = context.Set<Client>()
                .Include("Applications")
                .Where(a => a.Id == clientId)
                .FirstOrDefault();

            return client.Applications.Contains(application);
        }

    }
}