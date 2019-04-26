using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CustomerDao
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        public long AddCustomer(customer customer)
        {

            db.customers.Add(customer);            
            db.SaveChanges();
            
            long id_Customer = customer.id;
            return id_Customer;
        }
        public IEnumerable<customer> ListAllCustomer(string searchString,int page, int pagesize)
        {
            IQueryable<customer> model = db.customers;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name == searchString);
            }
            var result = model.OrderByDescending(x => x.created_at).ToPagedList(page, pagesize);
            return result;
        }

    }
}
