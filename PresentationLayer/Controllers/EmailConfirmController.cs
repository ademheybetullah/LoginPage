using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class EmailConfirmController : Controller
    {
        UserBusiness userBusiness = new UserBusiness();
        [HttpGet]
        public ActionResult ConfirmEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConfirmEmail(int code, string email)
        {
            var user = userBusiness.GetUserByEmail(email);
            if (user == null)
            {
                TempData["ErrorCard"] = "<script>alert('Bu epostaya kayıtlı kullanıcı buulunamadı.');</script>";
                return View();
            }
            if (user.ConfirmCode == code)
            {
                user.isConfirmed = true;
                userBusiness.UserUpdate(user);
                return RedirectToAction("Login", "Login");
            }
            else
            {
                TempData["ErrorCard"] = "<script>alert('Doğrulama kodunu yanlış girdiniz');</script>";
                return View();
            }
        }
    }
}