using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT_App.Models
{
    public class StateModel
    {
        public string StateProvince { get; set; }
        public int? ProductId { get; set; }
        public decimal LineTotal { get; set; }
        public string ProductName { get; set; }
    }
}