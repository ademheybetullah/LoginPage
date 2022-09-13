using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserBusiness
    {
        GenericRepository<User> repo = new GenericRepository<User>();

        public List<User> GetUserList()
        {
            return repo.List();
        }
        public void AddUser(User user)
        {
            repo.Insert(user);
        }

        public void UserUpdate(User user)
        {
            repo.Update(user);
        }
        public User GetUserByEmail(string email)
        {
            return repo.Get(x => x.Email == email);
        }
    }
}
