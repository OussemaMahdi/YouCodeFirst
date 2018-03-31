using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSite.Dal.DataBase;
using WebSite.Dal.Models;

namespace WebSite.ViewModels
{
    public class ClientDisplayViewModel
    {
        public int Id { get; set; }
        public String ClientCode { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
