using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Dal.Models
{
    [Table("Application")]
    public class Application
    {
        public Application()
        {
            this.Operations = new HashSet<Operation>();
        }

        [Key]
        public int ApplicationId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        //Start to the mapping
        public virtual ICollection<Operation> Operations { get; set; } //one to many 

    }
}
