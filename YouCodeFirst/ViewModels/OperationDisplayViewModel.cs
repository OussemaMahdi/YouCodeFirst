using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebSite.ViewModels;
using WebSite.Dal.Models;

namespace WebSite.ViewModels
{
    public class OperationDisplayViewModel
    {
        public int OperationId { get; set; }
        public string Name { get; set; }
        public OperationType Type { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ListAttribute ListAttributes { get; set; }
    }
}