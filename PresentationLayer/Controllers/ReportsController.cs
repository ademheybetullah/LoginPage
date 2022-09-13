using BusinessLayer.Concrete;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class ReportsController : Controller
    {
        UserBusiness userBusiness = new UserBusiness();
        LoginReportBusiness loginBusiness = new LoginReportBusiness();
        [HttpGet]
        public ActionResult UserReport()
        {
            UserReportModel report = new UserReportModel();
            var Users = userBusiness.GetUserList();
            foreach (var item in Users)
            {
                if (item.isOnline)
                    report.OnlineUsers++;
                TimeSpan ts = DateTime.Now - item.RegistrationDate;
                if (ts.Days >= 1 && item.isConfirmed == false)
                    report.UnconfirmedUsers++;
            }
            
            return View(report);
        }

        [HttpPost]
        public ActionResult LoginTimeReport(DateTime date)
        {
            LoginReportModel loginReportModel = LoginReportModel.getModel();
            if (date == loginReportModel.SearchedDate && date.Date != DateTime.Now.Date)
            {
                return View(loginReportModel);
            }
            loginReportModel.SearchedDate = date;
            float loginTime = 0;
            float loginCount = 0;
            var Logins = loginBusiness.GetAllLogins();
            
                foreach (var item in Logins)
                {
                    if (date.Date == item.LoginDate.Date)
                    {
                        loginCount++;
                        loginTime += item.LoginTime;
                    }
                }
                if (loginCount != 0)
                {
                    loginTime = loginTime / loginCount;
                    loginReportModel.LoginTime = (loginTime / 1000);
                }
            else { 
                    loginReportModel.LoginTime = 0;
            }
            return View(loginReportModel);
        }
        [HttpGet]
        public ActionResult LoginTimeReport()
        {
            LoginReportModel _model = LoginReportModel.getModel();
            return View(_model);
        }

        [HttpPost]
        public ActionResult RegistrationReport(DateTime startDate, DateTime endDate)
        {
            RegistrationReportModel model = new RegistrationReportModel();
            model.StartDate = startDate;
            model.EndDate = endDate;
            var users = userBusiness.GetUserList();
            int registrationCount = 0;
            foreach (var item in users)
            {
                if (item.RegistrationDate <= endDate && item.RegistrationDate >= startDate && item.isConfirmed == true)
                    registrationCount++;
            }
            model.RegistrationCount = registrationCount;

            return View(model);
        }
        [HttpGet]
        public ActionResult RegistrationReport(RegistrationReportModel model)
        {
            return View(model);
        }
    }
}