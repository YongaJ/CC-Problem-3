using CCProblem3.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCProblem3.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var list = DapperORM.ReturnList<OrderModel>("ViewAllOrders", null);
            return View(DapperORM.ReturnList<OrderModel>("ViewALLOrders",null));
        }

        public ActionResult ViewSupplierStock(int ?supplieID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SupplierID", supplieID);
            var list = DapperORM.ReturnList<ProductModel>("ViewSupplierStock", param);
            return View(DapperORM.ReturnList<ProductModel>("ViewSupplierStock", param));
        }

        [HttpPost]
        public ActionResult AddOrder(AddProductModel order)
        {
            if (order == null)
            {
                return RedirectToAction("ViewSupplierStock");
            }


            decimal total = 0;
            decimal subtotal = 0;
            int suppl = 8; 
            int VAT =Convert.ToInt16(ConfigurationManager.AppSettings["VAT"]);

            //foreach(var item in order)
            //{
            //    total = total + item.Price;
            //}

            subtotal = total + (total / 100 * VAT);

            DynamicParameters param = new DynamicParameters();
            //param.Add("@OrderId", item.OrderID);
            param.Add("@OrderNumber", Guid.NewGuid());
            param.Add("@Date", DateTime.Now.ToShortDateString());
            param.Add("@Supplier", suppl);
            param.Add("@Total", total);
            param.Add("@VAT", VAT);
            param.Add("@ProductsSubtotal", subtotal);


            DapperORM.ExecuteWithoutReturn("OrdersADDorDelete", param);
            return RedirectToAction("Index");

            return View(); 
        }
    }
}