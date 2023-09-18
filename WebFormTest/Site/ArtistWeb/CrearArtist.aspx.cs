using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormTest.Site.ArtistWeb
{
    public partial class CrearArtist : System.Web.UI.Page
    {
        private UnitOfWork _Unit;

        public CrearArtist()
        {
            _Unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var artista = new Artist { Name=txtName.Text };
            _Unit.Artists.Add(artista);
            if (_Unit.Complete() > 0)
            {
                Response.Redirect("ListaArtist.aspx");
            }
        }
    }
}