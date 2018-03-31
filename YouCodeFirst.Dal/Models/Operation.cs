using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Dal.Models
{
    [Table("Operation")]
    public class Operation
    {
        [Key]
        public int OperationId { get; set; }
        [MaxLength(55)]
        public string Name { get; set; }
        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }

        //Start to the mapping

        public OperationType Type { get; set; } // one to many

    }
}
