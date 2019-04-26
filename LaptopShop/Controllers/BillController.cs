using LaptopShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        private const string CartSession = "CartSession";
        [AllowAnonymous]
        public ActionResult Index()
        {
            var cart = Session["CartSession"];
            var list = (List < CartItem >) cart;
            TempData["CartSuccess"] = "Bạn đã mua hàng thành công";
            return View(list);
        }
    }
}