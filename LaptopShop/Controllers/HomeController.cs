using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchString,long id=0, int page=1)
        {
            var dao = new ProductDao();
            int pagesize = 4;
            var model = dao.GetAllProduct(searchString,id,page,pagesize);
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult TopProduct()
        {
            var dao = new ProductDao().TopListProduct();
            //var listproduct = dao.TopListProduct();
            return PartialView(dao);
        }
      
    }
}


