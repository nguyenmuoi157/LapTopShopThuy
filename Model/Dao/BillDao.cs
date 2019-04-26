using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BillDao
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        public long AddBill(bill bill)
        {
            db.bills.Add(bill);
            db.SaveChanges();
            var idbill = bill.id;
            return idbill;
        }
        public bool AddBillDetail(bill_detail bill)
        {
            var succsess = false;
            try
            {
                db.bill_detail.Add(bill);
                db.SaveChanges();
                succsess = true;
            }
            catch (Exception ex)
            {
                succsess = false;
                throw;
            }
            return succsess;
        }
        public IEnumerable<bill> GetAllBill(int searchString, int page, int pagesize)
        {
            IQueryable<bill> model = db.bills;
            if(searchString != 0)
            {
                model = model.Where(x => x.id == searchString);
            }
            var result = model.OrderByDescending(x => x.created_at).ToPagedList(page, pagesize);
            return result;
        }


        public IEnumerable<bill_detail> GetBillDetail(int id)
        {
            var model = db.bill_detail.Where(p=>p.id_bill == id);
           // var result = model.Where(p=>p.id_bill ==id).OrderByDescending(x => x.created_at).ToPagedList(page, pagesize);
            return model;
        }

    }
}
