using LaptopShop.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult Index(string searchString)
        {
            var dao = new UserDao();
            var model = dao.GetAllUser(searchString);

            return View(model);
        }

        public ActionResult ModifyRole(long userID, int RoleId)
        {
            var dao = new UserDao();
            var userLogin = (user)Session["loginsession"];
            bool result = dao.SetRoleUser(userLogin.id, userID, RoleId);
            var model = dao.GetAllUser(null);

            if (result)
            {
                ViewBag.isColoi = false;
                return View("Index",model);
            }
            else
            {
                ViewBag.isColoi = false;
                ViewBag.Loi = "Có lỗi xảy ra, vui lòng thử lại";
                return View("Index", model);
            }

           
        }
    }
}