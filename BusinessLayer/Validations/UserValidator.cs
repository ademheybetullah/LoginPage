using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not be empty");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname must not be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email must not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must not be empty");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must be at least 6 characters");
        }
    }
}
