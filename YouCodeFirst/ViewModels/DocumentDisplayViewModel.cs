using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSite.Dal.DataBase;
using WebSite.Dal.Models;

namespace WebSite.ViewModels
{
    public class DocumentDisplayViewModel
    {
        public int Id { get; set; }
        public StatusDocument Status { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Dal.Models.Attribute> Attributes { get; set; }
        public Operation Operation { get; set; }
        public string scanFileName { get; set; }
        public ICollection<Key> Keys { get; set; }
    }
}
