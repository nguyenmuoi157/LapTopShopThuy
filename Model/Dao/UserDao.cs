using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {
        LaptopShopDbContext db = new LaptopShopDbContext();
        public user GetUser(string userName, string passWord)
        {
            return db.users.Where(x => x.username == userName && x.password == passWord).SingleOrDefault();
        }
        public void AddUser(user user)
        {
            db.users.Add(user);
            db.SaveChanges();
        }
        public List<user> GetAllUser(string searchString)
        {
            IQueryable<user> model = db.users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => string.IsNullOrEmpty(searchString) || x.full_name == searchString || x.username == searchString);
            }
            return model.ToList();
        }

        public bool SetRoleUser(long userLogin, long user, int Roleid)
        {
            var _userLogin = db.users.SingleOrDefault(p => p.id == userLogin);
            if (_userLogin.RoleID != 1)
            {
                return false;
            }

            var _user = db.users.SingleOrDefault(p => p.id == user);
            if (_user != null)
            {
                var test = db.users.Where(p => p.RoleID == 1).ToList();
                if (test.Count == 1 && _user.RoleID == 1 && Roleid == 2)
                {
                    return false;
                }

                _user.RoleID = Roleid;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
