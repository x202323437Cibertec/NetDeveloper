using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebForms.App_Code
{
    public class BasePage: System.Web.UI.Page
    {
        string strConfig0 = ConfigurationManager.AppSettings["asKeyFlagAutenticationBasic"];

        protected void VerifyUser()
        {
            if (!string.IsNullOrEmpty(strConfig0) && strConfig0 == "1")
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    RedirectToLogin();
                }
            }
        }

        protected void IsUserInRole(string pRole)
        {
            if (!string.IsNullOrEmpty(strConfig0) && strConfig0 == "1")
            {
                if (!HttpContext.Current.User.IsInRole(pRole))
                {
                    RedirectToLogin();
                }
            }
        }

        private void RedirectToLogin()
        {
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}