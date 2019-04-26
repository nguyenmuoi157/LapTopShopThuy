using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class DetailProductController : Controller
    {
        // GET: DetailProduct
        public ActionResult Index(int id)
        {
            var dao = new ProductDao();
            var model = dao.GetProduct(id);
            return View(model);
        }
    }
}