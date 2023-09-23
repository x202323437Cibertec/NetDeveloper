using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Exception str0 = Application["aekError"] as Exception;
                if (str0 != null)
                {
                    lblError.Text = str0.Message;
                    lblError.Text += Environment.NewLine + str0.InnerException;
                    lblError.Text += Environment.NewLine + str0.StackTrace;
                }
            }
        }
    }
}