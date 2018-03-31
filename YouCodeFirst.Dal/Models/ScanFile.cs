using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Dal.Models
{
    [Table("ScanFile")]
    public class ScanFile
    {
        public int ScanFileId { get; set; }
        public string Name { get; set; }

        //Start to the mapping
        
        public virtual Document Document { get; set; } //one to one 
    }
}
