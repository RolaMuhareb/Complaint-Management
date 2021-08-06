using DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComplaintManagement.Models
{
    public class AuthorizeCustom : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAdmin = Convert.ToInt32(HttpContext.Current.Session["UserRole"]) == (int)UserRole.MxAdmin;
               return isAdmin;
        }
    }
}