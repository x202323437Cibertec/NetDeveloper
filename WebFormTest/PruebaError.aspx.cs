using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormTest
{
    public partial class PruebaError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnError_Click(object sender, EventArgs e)
        {
            throw new Exception("Error controlado de prueba");
        }
    }
}