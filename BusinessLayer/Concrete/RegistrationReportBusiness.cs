using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RegistrationReportBusiness
    {
        GenericRepository<Registration> repo = new GenericRepository<Registration>();
        public List<Registration> GelAllRegistrations()
        {
            return repo.List();
        }
        public void AddRegistration(Registration registration)
        {
            repo.Insert(registration);
        }
    }
}
