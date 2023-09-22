using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebForms.Site.ArtistWeb
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
                CargarPorPagina(1);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar_Nombre.Text))
            {
                int indexA = int.Parse(lblPagina.Text);
                CargarPorPagina(indexA);
            }
            else
            {
                Cargar_lista_PorNombre();
            }
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            CargarPorPagina(1);
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            int registros = TotalRegistros();
            int filasPorPagina = ArtistGridView.PageSize;
            int paginaA = (registros / filasPorPagina);
            int paginaB = ((registros % filasPorPagina) > 0) ? 1 : 0;
            int pagina = paginaA + paginaB;
            CargarPorPagina(pagina);
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            int page0 = int.Parse(lblPagina.Text) - 1;
            CargarPorPagina(page0);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int page0 = int.Parse(lblPagina.Text) + 1;
            CargarPorPagina(page0);
        }

        //private void Cargar_lista_General()
        //{
        //    IEnumerable<Artist> lArtistas = _Unit.Artists.GetArtistsByStore();
        //    List<Artist> listaArtistas = lArtistas.ToList();
        //    ArtistGridView.DataSource = listaArtistas;
        //    ArtistGridView.DataBind();
        //}

        private void Cargar_lista_PorNombre()
        {
            Artist cArtista = _Unit.Artists.GetByName(txtBuscar_Nombre.Text);
            List<Artist> listaArtistas = new List<Artist>();
            listaArtistas.Add(cArtista);
            ArtistGridView.DataSource = listaArtistas;
            ArtistGridView.DataBind();
            ActualizarPaginacion(1);
        }

        protected void ArtistGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int iPageIndex = e.NewPageIndex;
            ArtistGridView.PageIndex = iPageIndex;
            CargarPorPagina(iPageIndex);
        }

        public void CargarPorPagina(int pPageIndex)
        {
            int pageSize = ArtistGridView.PageSize;
            int pageIndex = pPageIndex;

            IEnumerable<Artist> eArtistas = _Unit.Artists.GetArtistPage(pageIndex, pageSize);
            List<Artist> lArtistas = eArtistas.ToList();

            ArtistGridView.DataSource = lArtistas;
            ArtistGridView.DataBind();

            ActualizarPaginacion(pPageIndex);
        }

        public void ActualizarPaginacion(int pIndex)
        {
            lblPagina.Text = pIndex.ToString();
            ActualizarTotalPaginacion();
        }

        private void ActualizarTotalPaginacion()
        {
            int registros = TotalRegistros();
            int filasPorPagina = ArtistGridView.PageSize;
            int paginaA = (registros / filasPorPagina);
            int paginaB = ((registros % filasPorPagina) > 0) ? 1 : 0;
            int pagina = paginaA + paginaB;
            lblPaginasTotales.Text = pagina.ToString();
        }

        public int TotalRegistros()
        {
            return _Unit.Artists.Count();
        }

        



    }
}