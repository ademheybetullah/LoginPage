using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        UserBusiness userBusiness = new UserBusiness();
        LoginReportBusiness loginBusiness = new LoginReportBusiness();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User _user)
        {
            DateTime Date1 = DateTime.Now;
            User user = userBusiness.GetUserByEmail(_user.Email);
            if (user == null)
            {
                TempData["ErrorCard"] = "<script>alert('Kullanıcı Bulunamadı');</script>";
                return View(_user);
            }
            if (_user.Password == user.Password)
            {
                if (user.isConfirmed)
                {
                    Login newLogin = new Login();
                    user.isOnline = true;
                    userBusiness.UserUpdate(user);
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Session["UserEmail"] = user.Email;
                    Session["UserRole"] = user.RoleId;
                    Session["isOnline"] = user.isOnline;
                    DateTime Date2 = DateTime.Now;
                    var mSecconds = (Date2 - Date1).TotalMilliseconds;
                    newLogin.LoginTime = Convert.ToInt32(mSecconds);
                    newLogin.LoginDate = Date1;
                    loginBusiness.AddLogin(newLogin);
                    return RedirectToAction("HomePage", "Home", user);

                }
                else
                {
                    TempData["ErrorCard"] = "<script>alert('Lütfen epostanızı onaylayınız.');</script>";
                    return View(_user);
                }


            }
            else
            {
                TempData["ErrorCard"] = "<script>alert('Şifre Yanlış Tekrar Deneyiniz.');</script>";
                return View(_user);
            }
        }
    }
}