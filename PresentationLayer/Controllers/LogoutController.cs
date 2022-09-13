using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PresentationLayer.Controllers
{
    public class LogoutController : Controller
    {
        UserBusiness userBusiness = new UserBusiness();
        public ActionResult Logout()
        {
            var user = userBusiness.GetUserByEmail(Session["UserEmail"].ToString());
            FormsAuthentication.SignOut();
            Session.Clear();
            user.isOnline = false;
            userBusiness.UserUpdate(user);
            return RedirectToAction("Login", "Login");
        }
    }
}