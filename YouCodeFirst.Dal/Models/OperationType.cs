using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebSite.Dal.Models
{
    [Table("OperationType")]
    public class OperationType
    {

        public int OperationTypeId { get; set; }

        public OpType name { get; set; }


        public OperationType()
        {
            this.name = OpType.Unspecified; // valeur par defaut
        }

        public ListAttribute ListAttribute { get; set; } //one to many
    }
}
