using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        LaptopShopDbContext db = new LaptopShopDbContext();

        public bool AddProduct(product product)
        {
            var result = true;
            try
            {
                var productadd = db.products.Add(product);
                var id = productadd.id;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;

        }

        public IEnumerable<product> GetAllProduct(string searchString,long id,int page,int pagesize)
        {
            
            IQueryable<product> model = db.products;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString));
            }
            if(id!=0)
            {
                model = model.Where(x => x.id_type == id);
            }
            var result = model.OrderByDescending(x => x.created_at).ToPagedList(page, pagesize);
            return result;
        }
        public product GetProduct(long id)
        {
            return db.products.Find(id);
        }
        public bool EditProduct(product product)
        {
            var pro = db.products.Find(product.id);
            if (pro != null)
            {
                pro.name = product.name;
                pro.id_type = product.id_type;
                pro.description = product.description;
                pro.unit_price = product.unit_price;
                pro.promotion_price = product.promotion_price;
                pro.image = product.image;
                pro.isSale = product.isSale;
                pro.created_at = product.created_at;
                pro.updated_at = product.updated_at;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            var pro = db.products.Find(id);
            if (pro != null)
            {
                db.products.Remove(pro);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<product> ListAllPaging(int page, int pagesize, string searchString)
        {
            IQueryable<product> model = db.products;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.created_at).ToPagedList(page, pagesize);
        }
        public bool AddViewCount(long count)
        {

            return true;
        }
        public void Editviewcount(product product, int soluong)
        {
            var pro = db.products.Find(product.id);
            if (pro.viewCount == null)
            {
                pro.viewCount = 0;
            }

            pro.viewCount = pro.viewCount + soluong;
            db.SaveChanges();
        }
        public List<product> TopListProduct()
        {
            var topProductsIds = db.products.GroupBy(x => x.id).OrderByDescending(g => g.Count()).Take(8).Select(x => x.Key).ToList();
            var topProducts = db.products.Where(x => topProductsIds.Contains(x.id)).ToList();
            //var topProduct = db.products.OrderByDescending(p => p.viewCount).Take(8).ToList();
            return topProducts;
        }

        

    }
}
