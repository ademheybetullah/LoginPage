using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class UserReportModel
    {
        public int OnlineUsers { get; set; }
        public int UnconfirmedUsers { get; set; }
    }
}