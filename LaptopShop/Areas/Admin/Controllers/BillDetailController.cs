using LaptopShop.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class BillDetailController : Controller
    {
        // GET: Admin/BillDetail
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult Index(int searchString= 0, int page=1)
        {
            int pagesize = 4;
            var dao = new BillDetailDao();
            var model = dao.GetAllBillDetail(searchString, page, pagesize);
            return View(model);
        }
    }
}