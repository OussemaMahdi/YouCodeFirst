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
using WebSite.Dal.Models.Account;

namespace WebSite.Repositories
{
    public class ClientRepository : EntityRepository<WebSiteDBContext, Client, int>, IClientRepository
    {
        public ClientRepository(WebSiteDBContext context)
            : base(context)
        {
        }

        public Client getClientById(WebSiteDBContext context, string id)
        {

            Client client = context.Set<Client>()
                .Include("Applications")
                .Where(c => c.Id == id)
                .FirstOrDefault();

            return client;
        }

        public IList<ApplicationDisplayViewModel> getClientApplications(WebSiteDBContext context, string id)
        {
            Client client = getClientById(context, id);

            var data = client.Applications;
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



    }
}