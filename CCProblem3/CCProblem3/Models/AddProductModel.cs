using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCProblem3.Models
{
    public class AddProductModel
    {
        public newList newList { get; set; }


    }

    public class newList
    {
        public string ProdId { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Volume { get; set; }
        public int Ordered { get; set; }

    }
}