using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Dal.Models
{
    public enum StatusDocument
    {
        Unspecified = 0, 
        Validated = 1, 
        Rejected = 2, 
        BenignAnomaly = 3, //anomalie non bloquante
        Anomaly = 4, //anomalie bloquante
        ValidatedAnomaly = 5,
        RejectedAnomaly = 6, 
        OutOfDate = 7,
    }
}
