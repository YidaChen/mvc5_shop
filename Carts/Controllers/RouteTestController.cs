using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carts.Controllers
{
    public class RouteTestController : Controller
    {
        // GET: RouteTest
        public ActionResult Index()
        {
            //取得所有商品，放入result
            var result = Models.RouteTest.TempProducts.getAllproducts();
            List<Models.RouteTest.TempProducts>[] arr = { result };
            //將result(所有商品)傳送給View
            return View(arr);
        }
        public ActionResult Index2(string id)
        {
            return Content(
                String.Format("id為: {0}", id)
                );
        }
        public ActionResult Index3(string id, string page)
        {
            return Content(
                String.Format("id為: {0}; page為: {1}", id, page)
                );
        }
    }
}