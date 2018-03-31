using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

using WebSite.Dal.Models.Account;

namespace WebSite.Dal.Models
{
    
    public class Client : ApplicationUser
    {
        public Client()
        {
            this.Applications = new HashSet<Application>();
            
            // Choisir le role d'un client par defaut
            //this.Roles.Add(new AppRole("Client"));
        }

        public string ClientCode { get; set; }

        public string Name { get; set; }


        //Start to the mapping

        public virtual ICollection<Application> Applications { get; set; } //one to many 
    }
}
