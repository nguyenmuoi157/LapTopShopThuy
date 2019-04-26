using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class TypeProductController : Controller
    {
        // GET: TypeProduct
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var dao = new TypeProductDao();
            var model = dao.ListAllTypeProduct();
            return PartialView(model);
        }
    }
}