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
    public class CustomerController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCustomer(customer customer )
        {
            if(ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var billDao = new BillDao();


                var cart = Session[CartSession];
                var listProduct = (List<CartItem>)cart;
                var dao_product = new ProductDao();
                foreach(var item in listProduct)
                {
                    var product = item.Product;
                    var soluong = item.Quantity;
                    dao_product.Editviewcount(product, soluong);
                }
                double tongtien = 0.0f;

                foreach (var item in listProduct)
                {
                    if(item.Product.isSale)
                    {
                        tongtien += item.Quantity * item.Product.promotion_price.Value;
                    }
                    else
                    {
                        tongtien += item.Quantity * item.Product.unit_price.Value;
                    }
                    
                }
                customer.created_at = DateTime.Now;
                var idCustomer =  dao.AddCustomer(customer);

                var bill = new bill()
                {
                    created_at = DateTime.Now,
                    date_order = DateTime.Now,
                    id_customer = idCustomer,
                    total = (float)tongtien,
                   
                };

                var idBill = billDao.AddBill(bill);

                foreach (var item in listProduct)
                {
                    var billDetail = new bill_detail()
                    {
                        id_bill = (int)idBill,
                        id_product = (int)item.Product.id,
                        quantity = item.Quantity,
                        unit_price = item.Product.isSale ? (float)item.Product.promotion_price : item.Product.unit_price,
                        created_at = DateTime.Now

                    };

                    billDao.AddBillDetail(billDetail);
                }
                return RedirectToAction("Index", "Bill");
            }
            else
            {
                ModelState.AddModelError("", "dang ky khong dung");
                return RedirectToAction("Index", "Bill");
            }
            
        }
    }
}