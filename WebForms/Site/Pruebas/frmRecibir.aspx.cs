using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.Pruebas
{
    public partial class frmRecibir : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string strRecibido = "Vacio";
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Form["dato"]))
                {
                    strRecibido = Request.Form["dato"];
                    Session["sDato"] = strRecibido;
                }
            }
            lblDato.Text = Session["sDato"].ToString();
        }
    }
}