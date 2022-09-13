using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Login> LoginReports { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
