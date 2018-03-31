using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Dal.Models
{
    [Table("Key")]
    public class Key
    {
        public int KeyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ListAttribute> ListAttributes { get; set; } //many to many

    }
}
