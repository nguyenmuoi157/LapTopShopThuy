using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopShop.Models;
using Model.Dao;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        private const string loginsession = "loginsession";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            var dao = new UserDao();
            var user = dao.GetUser(model.UserName, model.PassWord);
            if (user != null)
            {
                Session[loginsession] = user;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng hoặc chưa đăng ký");
                
            }
            return View("Index");
        }
    }
}