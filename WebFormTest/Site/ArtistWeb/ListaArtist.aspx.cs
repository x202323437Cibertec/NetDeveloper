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
    public partial class ListaArtist : System.Web.UI.Page
    {
        private UnitOfWork _Unit;

        public ListaArtist()
        {
            _Unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Cargar_lista_General();
            }
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            ArtistGridView.SelectedIndex = 0;
            ArtistGridView.PageIndex = 0;
            ArtistGridView.DataBind();
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            int intLastRowIndex = ArtistGridView.Rows.Count - 1;
            ArtistGridView.SelectedIndex = intLastRowIndex;
            int intLastPageIndex = ArtistGridView.PageCount - 1;
            ArtistGridView.PageIndex = intLastPageIndex;
            ArtistGridView.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar_Nombre.Text))
            {
                Cargar_lista_General();
            }
            else
            {
                Cargar_lista_PorNombre();
            }
        }

        private void Cargar_lista_General()
        {
            IEnumerable<Artist> lArtistas = _Unit.Artists.GetArtistsByStore();
            List<Artist> listaArtistas = lArtistas.ToList();
            ArtistGridView.DataSource = listaArtistas;
            ArtistGridView.DataBind();
        }

        private void Cargar_lista_PorNombre()
        {
            Artist cArtista = _Unit.Artists.GetByName(txtBuscar_Nombre.Text);
            List<Artist> listaArtistas = new List<Artist>();
            listaArtistas.Add(cArtista);
            ArtistGridView.DataSource = null;
            ArtistGridView.DataSource = listaArtistas;
            ArtistGridView.DataBind();
        }

        protected void ArtistGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int iPageIndex = e.NewPageIndex + 1;
            int iPageSize = ArtistGridView.PageSize;
            IEnumerable<Artist> lArtistas = _Unit.Artists.GetArtistPage(iPageIndex, iPageSize);
            List<Artist> listaArtistas = lArtistas.ToList();
            ArtistGridView.DataSource = listaArtistas;
            ArtistGridView.DataBind();
            ArtistGridView.SelectedIndex = -1;
            //ArtistGridView.BottomPagerRow.Visible = true;
            //ArtistGridView.PageIndex = e.NewPageIndex;
            //ArtistGridView.PagerSettings.Position = PagerPosition.TopAndBottom;
            //ArtistGridView.PagerSettings.Mode = PagerButtons.NumericFirstLast;
            //ArtistGridView.PagerSettings.Visible = true;
            //ArtistGridView.DataBind();
        }
    }
}