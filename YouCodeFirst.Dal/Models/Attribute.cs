using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Dal.Models
{
    [Table("Attribute")]
    public class Attribute
    {
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public Attribute()
        {
            this.Value = "Not defined"; // valeur par defaut
        }

        public Attribute(Key Key)
        {
            this.Value = "Not defined";
            this.Key = Key;
        }

        //Start to the mapping

        public Key Key { get; set; } //one to many

    }
}
