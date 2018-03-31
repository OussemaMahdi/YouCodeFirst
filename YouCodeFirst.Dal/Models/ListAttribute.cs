using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Dal.Models
{
    [Table("ListAttribute")]
    public class ListAttribute
    {
        public ListAttribute()
        {
            this.Keys = new HashSet<Key>();
        }

        public int ListAttributeId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Visiblity { get; set; }


        //Start to the mapping

        public virtual ICollection<Key> Keys { get; set; } // many to many



    }
}
