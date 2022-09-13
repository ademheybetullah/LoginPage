using BackendTask.EmailSender;
using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        UserBusiness userBusiness = new UserBusiness();
        private IEmailSender _emailSender = new SmtpEmailSender(
                    "smtp.office365.com",
                    587,
                    true,
                    "login_page0@hotmail.com",
                    "Sifre99."
            );


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User _user)
        {
            _user.RegistrationDate = DateTime.Now;
            Random rastgele = new Random();
            int confirmCode = rastgele.Next(1000, 10000);
            _user.ConfirmCode = confirmCode;
            _user.RoleId = 1;
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(_user);
            if (results.IsValid)
            {
                userBusiness.AddUser(_user);
                _emailSender.SendEmailAsync(_user.Email, "Hesap Onayı", $"Hesap onay kodnuz:{confirmCode} kodu girmek için <a href='https://localhost:44390/EmailConfirm/ConfirmEmail'> tıklayınız <a/>");
                return RedirectToAction("ConfirmEmail", "EmailConfirm");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }
    }
}