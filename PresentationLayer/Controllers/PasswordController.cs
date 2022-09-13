using BackendTask.EmailSender;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class PasswordController : Controller
    {
        UserBusiness userBusiness = new UserBusiness();
        private IEmailSender _emailSender = new SmtpEmailSender(
                    "smtp.office365.com",
                    587,
                    true,
                    "login_page0@hotmail.com",
                    "Sifre99."
            );
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            var user = userBusiness.GetUserByEmail(email);
            if (user == null)
            {
                TempData["ErrorCard"] = "<script>alert('Bu epostaya kayıtlı kullanıcı bulunamadı.');</script>";
                return View();
            }
            else
            {
                Random rastgele = new Random();
                int Code = rastgele.Next(1000, 10000);
                user.ForgotPasswordCode = Code;
                userBusiness.UserUpdate(user);
                _emailSender.SendEmailAsync(user.Email, "Şifre Değiştirme", $"Hesap onay kodnuz:{Code} kodu girmek için <a href='https://localhost:44390/Password/ChangePassword'> tıklayınız <a/>");
                return RedirectToAction("ChangePassword", "Password");
            }
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(User _user)
        {
            var user = userBusiness.GetUserByEmail(_user.Email);
            if (user == null)
            {
                TempData["ErrorCard"] = "<script>alert('Bu epostaya kayıtlı kullanıcı bulunamadı.');</script>";
                return View();
            }
            else
            {
                if (_user.ForgotPasswordCode == user.ForgotPasswordCode)
                {
                    user.Password = _user.Password;
                    userBusiness.UserUpdate(user);
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    TempData["ErrorCard"] = "<script>alert('Doğrulama kodu hatalı.');</script>";
                    return View();
                }
            }
        }
    }
}