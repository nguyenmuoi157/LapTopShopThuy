using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TypeProductDao
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        public List<type_products> ListAllTypeProduct()
        {
            return db.type_products.ToList();
        }
        public type_products GetTypeProduct(long id)
        {
            return db.type_products.Find(id);
        }
        public bool AddTypeProduct(type_products TypeProduct)
        {
            try
            {
                db.type_products.Add(TypeProduct);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditTypeProduct(type_products TypeProduct)
        {
            try
            {
                type_products pro = db.type_products.Find(TypeProduct.id);
                pro.name = TypeProduct.name;
                pro.description = TypeProduct.description;
                pro.image = TypeProduct.image;
                pro.created_at = TypeProduct.created_at;
                pro.updated_at = TypeProduct.updated_at;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteTypeProduct(long id)
        {
            try
            {
                var typepro = db.type_products.Find(id);
                db.type_products.Remove(typepro);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

    }
}
