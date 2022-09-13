using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int ConfirmCode { get; set; }
        public int ForgotPasswordCode { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime RegistrationDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime EmailConfirmDate { get; set; }

        public int RegistrationId { get; set; }
        public bool isOnline { get; set; }
        public bool isConfirmed { get; set; }
    }
}
