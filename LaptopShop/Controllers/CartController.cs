using LaptopShop.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        private const string CartSession = "CartSession";
        [AllowAnonymous]
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [AllowAnonymous]
        public ActionResult AddItem(int productId, int quatity)
        {
            var product = new ProductDao().GetProduct(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.id == productId))
                {
                    foreach (var item in list)
                    {
                        item.Quantity += 1;
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = 1;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quatity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index", "Home");
        }

        
        public JsonResult EditCart(int productId, int soluong)
        {
            try
            {
                var Cart = (List<CartItem>)Session[CartSession];
                foreach (var item in Cart)
                {
                    if (item.Product.id == productId)
                    {
                        item.Quantity = soluong;
                    }
                }

                Session[CartSession] = Cart;

                return Json(new
                {
                    status = true
                });
            }
            catch (Exception)
            {
                return Json(new { status = false });
                throw;
            }
        }
        [HttpGet]
        public ActionResult Delete(long id_Product)
        {

            var cart = (List<CartItem>)Session[CartSession];
           
            var deleteItem = cart.Where(p => p.Product.id == id_Product).SingleOrDefault();

            cart.Remove(deleteItem);
            Session[CartSession] = cart;
            return RedirectToAction("Index");
        }
    }
}