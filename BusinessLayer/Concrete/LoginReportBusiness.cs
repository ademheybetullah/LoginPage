using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginReportBusiness
    {
        GenericRepository<Login> repo = new GenericRepository<Login>();
        public List<Login> GetAllLogins()
        {
            return repo.List();
        }
        public void AddLogin(Login login)
        {
            repo.Insert(login);
        }
    }
}
