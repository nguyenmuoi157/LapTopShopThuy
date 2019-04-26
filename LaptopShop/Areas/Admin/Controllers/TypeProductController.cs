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
    public class TypeProductController : Controller
    {
        // GET: Admin/TypeProduct
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult Index(string searchString, int page = 1)
        {
            var dao = new CategoryDao();
            int pagesize = 4;
            var model = dao.GetTypeProductAll(searchString, page, pagesize);
            return View(model);
        }
        [HttpGet]
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult AddTypeProduct()
        {
            return View();
        }
        [HttpPost]
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult AddTypeProduct(type_products TypeProduct)
        {
            if (ModelState.IsValid)
            {
                TypeProduct.created_at = DateTime.Now;
                var dao = new TypeProductDao();
                var model = dao.AddTypeProduct(TypeProduct);
                TempData["success"] = "Add Success";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Fail");
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult EditTypeProduct(long id)
        {
            var dao = new TypeProductDao();
            var model = dao.GetTypeProduct(id);
            return View(model);
        }
        [HttpPost]
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult EditTypeProduct(type_products TypeProduct)
        {

            if (ModelState.IsValid)
            {
                var dao = new TypeProductDao();
                var CreatedAt = dao.GetTypeProduct(TypeProduct.id).created_at;
                TypeProduct.created_at = CreatedAt;
                TypeProduct.updated_at = DateTime.Now;
                dao.EditTypeProduct(TypeProduct);
                TempData["success"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Fail Edit");
                return View("Index");
            }
        }

        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult DeleteTypeProduct(long id)
        {
            var dao = new TypeProductDao();
            dao.DeleteTypeProduct(id);
            TempData["success"] = "Deleted Success";
            return RedirectToAction("Index", "TypeProduct");
        }
    }
}