using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.ViewModels
{
    public class AccueilViewModel
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public WebSite.Dal.Models.Attribute Attribute { get; set; }
    }
}