using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class LoginReportModel
    {
        public DateTime SearchedDate { get; set; }
        public float LoginTime { get; set; }
        public static LoginReportModel loginReportModel;
        private LoginReportModel()
        {

        }
        public static LoginReportModel getModel()
        {
            if (loginReportModel == null)
                loginReportModel = new LoginReportModel();
            return loginReportModel;
        }
    }
}