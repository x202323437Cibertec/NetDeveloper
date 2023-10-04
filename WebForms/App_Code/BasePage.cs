using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.App_Code
{
    public class BasePage: System.Web.UI.Page
    {
        protected void VerifyUser()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                RedirectToLogin();
            }
        }

        protected void IsUserInRole(string pRole)
        {
            if (!HttpContext.Current.User.IsInRole(pRole))
            {
                RedirectToLogin();
            }
        }

        private void RedirectToLogin()
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}