using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCProblem3.Models
{
    public class ProductModel
    {
        public string ProdId { get; set; }

        public string Description { get; set; }
            public decimal Price { get; set; }
            public string Volume { get; set; }
        public int Ordered { get; set; }
         

    }
}