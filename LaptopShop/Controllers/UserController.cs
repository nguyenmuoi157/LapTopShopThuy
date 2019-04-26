using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUser(user user)
        {
            if(ModelState.IsValid)
            {
                user.created_at = DateTime.Now;
                var dao = new UserDao();
                dao.AddUser(user);
            }
            else
            {
                ModelState.AddModelError("", "dang ky khong dung");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}