using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public int LoginTime { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime LoginDate { get; set; }
    }
}
