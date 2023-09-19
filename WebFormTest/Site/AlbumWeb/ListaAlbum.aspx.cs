using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebFormTest.Site.AlbumWeb
{
    public partial class ListaAlbum : System.Web.UI.Page
    {
        private UnitOfWork _Unit;

        public ListaAlbum()
        {
            _Unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_lista_General();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar_Titulo.Text))
            {
                Cargar_lista_General();
            }
            else
            {
                Cargar_lista_PorNombre();
            }
        }

        protected void AlbumGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AlbumGridView.SelectedIndex = -1;
            AlbumGridView.PageIndex = e.NewPageIndex;
            AlbumGridView.DataBind();
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            AlbumGridView.SelectedIndex = 0;
            AlbumGridView.PageIndex = 0;
            AlbumGridView.DataBind();
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            int intLastRowIndex = AlbumGridView.Rows.Count - 1;
            AlbumGridView.SelectedIndex = intLastRowIndex;
            int intLastPageIndex = AlbumGridView.PageCount - 1;
            AlbumGridView.PageIndex = intLastPageIndex;
            AlbumGridView.DataBind();
        }

        private void Cargar_lista_General()
        {
            IEnumerable<Album> lAlbumes = _Unit.Album.GetAll();
            List<Album> listAlbumes = lAlbumes.ToList();
            AlbumGridView.DataSource = listAlbumes;
            AlbumGridView.DataBind();
        }

        private void Cargar_lista_PorNombre()
        {
            Album cAlbum = _Unit.Album.GetByTitle(txtBuscar_Titulo.Text);
            List<Album> listaAlbumes = new List<Album>();
            listaAlbumes.Add(cAlbum);
            AlbumGridView.DataSource = listaAlbumes;
            AlbumGridView.DataBind();
        }


    }
}