using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BillDetailDao
    {
        LaptopShopDbContext db = new LaptopShopDbContext();

        public IEnumerable<bill_detail> GetAllBillDetail(int searchString,int page, int pagesize)
        {
            IQueryable<bill_detail> model = db.bill_detail;
            if(searchString!=0)
            {
                model = model.Where(x => x.id == searchString);
            }
            var result = model.OrderByDescending(x => x.created_at).ToPagedList(page, pagesize);
            return result;
        }
    }
}
