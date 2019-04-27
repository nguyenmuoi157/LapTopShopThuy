using LaptopShop.Areas.Admin.Models;
using LaptopShop.Common;
using LaptopShop.Controllers;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Admin/Profile
        [HttpGet]
        public ActionResult Index()
        {
            UserDao dao = new UserDao();
            var userLogin = (user)Session["loginsession"];
            EditUserModel editUser = new EditUserModel()
            {
                id = userLogin.id,
                Email = userLogin.email,
                FullName = userLogin.full_name,
                UserName = userLogin.username
            };
            return View(editUser);
        }

        // GET: Admin/Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Profile/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: Admin/Profile/Edit/5
        public ActionResult Edit(EditUserModel model)
        {
            UserDao dao = new UserDao();
            var userEdit = dao.GetUserById(model.id);
            if(userEdit!=null)
            {
                if(model.Password!=model.RePassword)
                {
                    ModelState.AddModelError("err", "Mật khẩu không khớp");
                    return RedirectToAction("Index");
                }

                userEdit.email = model.Email;
                userEdit.full_name = model.FullName;
                userEdit.password = model.Password;
                userEdit.updated_at = DateTime.Now;

                var result = dao.UpdateUser(userEdit);
                if(!result)
                {
                    ModelState.AddModelError("err", "Update không thành công");
                    return RedirectToAction("Index");
                }
                EditUserModel editUser = new EditUserModel()
                {
                    id = userEdit.id,
                    Email = userEdit.email,
                    FullName = userEdit.full_name,
                    UserName = userEdit.username
                };
                return View(editUser);


            }
            else
            {
                ModelState.AddModelError("err", "User không tồn tại");
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
