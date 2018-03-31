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
    public class DocumentRepository : EntityRepository<WebSiteDBContext, Document, int>, IDocumentRepository
    {
        public DocumentRepository(WebSiteDBContext context)
            : base(context)
        {
        }

        public bool IsDocumentExists(int id)
        {
            return _context.Documents.
                Any(o => o.documentId == id);
        }

        public IList<DocumentDisplayViewModel> DocumentDisplay(WebSiteDBContext context)
        {
            var data = context.Set<Document>().Include("Attributes").ToList();
            IList<DocumentDisplayViewModel> Display = new List<DocumentDisplayViewModel>();
            foreach (Document d in data)
            {
                DocumentDisplayViewModel aux = new DocumentDisplayViewModel();
                aux.Id = d.documentId;
                aux.scanFileName = d.scanFile.Name;
                aux.Status = d.status;
                aux.CreationDate = d.creationDate;
                aux.Operation = d.operation;
                Display.Add(aux);
            }
            return Display;
        }

        public Document getDocumentById(WebSiteDBContext context, int id)
        {
            Document d = context.Set<Document>()
                .Where(e => e.documentId == id).FirstOrDefault();
            return d;
        }

        

    }
}