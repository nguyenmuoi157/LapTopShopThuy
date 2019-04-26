using LaptopShop.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult Index(string searchString,int page=1)
        {
            int pagesize = 4;
            var dao = new CustomerDao();
            var model = dao.ListAllCustomer(searchString,page,pagesize);
            return View(model);
        }
    }
}