using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        public List<type_products> GetListTypeProduct()
        {
            return db.type_products.ToList();
        }
        public IEnumerable<type_products> GetTypeProductAll(string searchString, int page, int pagesize)
        {
            IEnumerable<type_products> model = db.type_products;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.created_at).ToPagedList(page, pagesize);
        }


    }
}
