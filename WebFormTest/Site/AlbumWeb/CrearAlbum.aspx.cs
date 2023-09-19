using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormTest.Site.AlbumWeb
{
    public partial class CrearAlbum : System.Web.UI.Page
    {
        private UnitOfWork _Unit;

        public CrearAlbum()
        {
            _Unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarArtistas();
            }
            
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var cAlbum = new Album { Title = txtTitulo.Text, ArtistId = Convert.ToInt32(ddlArtista.SelectedValue) };
            _Unit.Album.Add(cAlbum);
            if (_Unit.Complete() > 0)
            {
                Response.Redirect("ListaAlbum.aspx");
            }
        }

        private void CargarArtistas()
        {
            List<Artist> lArtistas = _Unit.Artists.GetAll().ToList();
            lArtistas.Insert(0, new Artist() { ArtistId = 0, Name = "Seleccione" });
            ddlArtista.DataSource = lArtistas;
            ddlArtista.DataTextField = "Name";
            ddlArtista.DataValueField = "ArtistId";
            ddlArtista.DataBind();
        }

    }
}