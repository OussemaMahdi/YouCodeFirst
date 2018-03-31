using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Dal.Models
{
    [Table("Document")]
    public class Document
    {
        public Document()
        {
            this.Attributes = new HashSet<Attribute>();
        }

        [Key, ForeignKey("scanFile")]
        public int documentId { get; set; }

        public StatusDocument status { get; set; }
        public DateTime creationDate { get; set; }

        //Start to the mapping

        public virtual Operation operation { get; set; } //one to many

        public virtual ICollection<Attribute> Attributes { get; set; } //one to many 

        public virtual ScanFile scanFile { get; set; } //one to one 



    }
}
