using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSite.Dal.DataBase;
using WebSite.Dal.Models;

namespace WebSite.ViewModels
{
    public class ApplicationDisplayViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Operation> Operations { get; set; }
    }
}
