using LaptopShop.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        // GET: Admin/Bill
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult Index(int searchString = 0,int page=1)
        {
            int pagesize = 4;
            var dao = new BillDao();
            var model = dao.GetAllBill(searchString, page, pagesize);
            return View(model);
        }

        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult Detail(int id)
        {
            var dao = new BillDao();
            var model = dao.GetBillDetail(id);
            return View(model);
        }
    }
}