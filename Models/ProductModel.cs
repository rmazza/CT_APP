using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT_App.Models
{
    public class ProductModel
    {
        public string SelectedState { get; set; }
        public string[] ArrayOfStates { get; set; }
        public List<SalesModel> sales { get; set; }
        public List<StateModel> state { get; set; }
    }
}