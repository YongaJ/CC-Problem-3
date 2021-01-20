using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCProblem3.Models
{
    public class OrderModel
    {
       public int OrderID { get; set; }
       public string OrderNumber { get; set; } 
        public string Date { get; set; }
        public int Supplier { get; set; }
        public decimal ProductsSubtotal { get; set; }

        public int VAT { get; set; }
        public string Total { get; set; }
    }
}