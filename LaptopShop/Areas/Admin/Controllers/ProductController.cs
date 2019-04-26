using LaptopShop.Areas.Admin.Models;
using LaptopShop.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        //public ActionResult Index()
        //{
        //    var dao = new ProductDao();
        //    var model = dao.GetAllProduct();
        //    return View(model);
        //}
        [HttpGet]
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult AddProduct()
        {
            var catdao = new CategoryDao();
            ViewBag.ListCategory = catdao.GetListTypeProduct().ToList();
            return View();
        }

        [HttpPost]
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult AddProduct(product product, HttpPostedFileBase images)
        {           
            if (images != null)
            {
                //Database1Entities db = new Database1Entities();
                string ImageName = System.IO.Path.GetFileName(images.FileName);
                string physicalPath = Server.MapPath("~/assets/images/" + ImageName);

                // save image in folder
                images.SaveAs(physicalPath);
                product.image = ImageName;
            }
            
            var dao = new ProductDao();
            product.created_at = DateTime.Now;
            if (dao.AddProduct(product))
            {

            }
            else
            {
                ModelState.AddModelError("", "sản phẩm chưa thêm được");
            }
            var catdao = new CategoryDao();
            ViewBag.ListCategory = catdao.GetListTypeProduct().ToList();
            TempData["success"] = "Added Product Successful";
            return RedirectToAction("Index","Product");
        }

        [HttpGet]
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult EditProduct(int id)
        {
            var productdao = new ProductDao();
            var categoryDao = new CategoryDao();           
            var product = productdao.GetProduct(id);
            
            var categoryList = categoryDao.GetListTypeProduct();
            ViewBag.ListCategory = categoryList;
            return View(product);
        }


        [HttpPost]
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult EditProduct(product product, HttpPostedFileBase images)
        {
            if (images != null)
            {
                //Database1Entities db = new Database1Entities();
                string ImageName = System.IO.Path.GetFileName(images.FileName);
                string physicalPath = Server.MapPath("~/assets/images/" + ImageName);

                // save image in folder
                images.SaveAs(physicalPath);
                product.image = ImageName;
            }

            product.updated_at = DateTime.Now;
            var dao = new ProductDao();
            var createdAt = dao.GetProduct(product.id).created_at;
            product.created_at = createdAt;
            if(dao.EditProduct(product))
            {
                TempData["Success"] = "Edited Successfully!";                
            }
            else
            {
                ModelState.AddModelError("", "Edit khong thanh cong");                
            }
            return RedirectToAction("index", "Product");
        }
        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult Delete(int id)
        {
            var dao = new ProductDao();
            if(dao.DeleteProduct(id))
            {
                TempData["Success"] = "Deleted Successfully!";
            }
            else
            {
                ModelState.AddModelError("", "delete khong thanh cong");
            }
            return RedirectToAction("index", "Product");
        }

        [RoleProviderCustome(RoleName = "Admin")]
        public ActionResult Index(string searchString,int page=1)
        {
            var dao = new ProductDao();
            int pagesize = 4;
            var model = dao.ListAllPaging(page, pagesize, searchString);

            return View(model);
        }
        //public ActionResult FileUpload(HttpPostedFileBase images, product product)
        //{

        //    if (images != null)
        //    {
        //        //Database1Entities db = new Database1Entities();
        //        string ImageName = System.IO.Path.GetFileName(images.FileName);
        //        string physicalPath = Server.MapPath("~/assets/images/" + ImageName);

        //        // save image in folder
        //        images.SaveAs(physicalPath);

                 
        //    }
        //    return RedirectToAction("Index","Product");
        //}
    }
}