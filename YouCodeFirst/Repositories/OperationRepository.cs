using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebSite.Repositories.Generic;
using WebSite.ViewModels;
using WebSite.Dal.Models;
using WebSite.Dal.DataBase;
using System.Collections.ObjectModel;

namespace WebSite.Repositories
{
    public class OperationRepository : EntityRepository<WebSiteDBContext, Operation, int>, IOperationRepository
    {
        public OperationRepository(WebSiteDBContext context)
            : base(context)
        {
        }

        public IList<OperationDisplayViewModel> OperationDisplay(WebSiteDBContext context)
        {
            var data = context.Set<Operation>().ToList();
            IList<OperationDisplayViewModel> Display = new List<OperationDisplayViewModel>();
            foreach (Operation operationId in data)
            {
                OperationDisplayViewModel aux = new OperationDisplayViewModel();

                aux.OperationId = operationId.OperationId;
                aux.Name = operationId.Name;
                aux.Type = operationId.Type;
                aux.Begin = (DateTime)operationId.Begin;
                aux.End = (DateTime)operationId.End;
                Display.Add(aux);
            }
            return Display;
        }

        // à refaire bricolage
        public bool AutorizeToClient(WebSiteDBContext context, int operationId, string clientId)
        {
            
            Operation operation = context.Set<Operation>()
                .Where(a => a.OperationId == operationId)
                .FirstOrDefault();


            Client client = context.Set<Client>()
                .Include("Applications.Operations")
                .Where(a => a.Id == clientId)
                .FirstOrDefault();
            foreach (Application app in client.Applications)
            {
                if (app.Operations.Contains(operation))
                    return true;
            }
            

            /*
            var res = from client in context.Set<Client>() where (client.Id==clientId)
                      join application in context.Set<Application>() on client.Applications equals application
                      join OperatingSystem
                      select client
                      
            */
            return false;
        }


        // à refaire c'est du bricolage :p
        public IList<DocumentDisplayViewModel> OperationDocumentsDisplay(WebSiteDBContext context, int operationId)
        {
            var data = context.Set<Document>()
                .Include("Attributes").Include("Operation.Type.ListAttribute.Keys")
                .Where(e => e.operation.OperationId == operationId)
                .ToList();

            IList<DocumentDisplayViewModel> display = new List<DocumentDisplayViewModel>();

            foreach (Document d in data)
            {
                DocumentDisplayViewModel aux = new DocumentDisplayViewModel();
                aux.Id = d.documentId;
                aux.Status = d.status;
                aux.CreationDate = d.creationDate;
                aux.Operation = d.operation;
                aux.Keys = d.operation.Type.ListAttribute.Keys;
                // Si le fichier existe
                if (d.scanFile != null)
                    aux.scanFileName = d.scanFile.Name;
                else
                    aux.scanFileName = "Not Found";

                aux.Attributes = new Collection<Dal.Models.Attribute>();
                int index = 0;
                foreach (Key key in aux.Keys)
                {
                    if (d.Attributes.ElementAt(index).Key == key)
                    {
                        var v = d.Attributes.ElementAt(index);
                        aux.Attributes.Add(d.Attributes.ElementAt(index));
                        index++;
                    }
                    else
                    {
                        aux.Attributes.Add(new Dal.Models.Attribute(key));
                    }
                }
                display.Add(aux);
            }

            return display;
        }
    }
}