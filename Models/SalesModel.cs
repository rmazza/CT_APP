using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT_App.Models
{
    public class SalesModel
    {
        public string StateProvince { get; set; }
        public int? ProductId { get; set; }
        public int? OrderQty { get; set; }
        public string ProductName { get; set; }
    }
}