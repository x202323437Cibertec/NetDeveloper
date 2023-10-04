using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.App_Code;

namespace WebForms.Site.PlaylistWeb
{
    public partial class wfListado : BasePage
    {
        private UnitOfWork _Unit;

        public wfListado()
        {
            _Unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                VerifyUser();
                IsUserInRole("USUARIO");
                Playlist_Cargar();
            }
        }

        protected void ddlPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PlaylistTrackVM> lRows = null;
            if (ddlPlaylist.SelectedIndex <= 0)
            {
                lRows = new List<PlaylistTrackVM>();
            }
            else
            {
                IEnumerable<PlaylistTrackVM> eRows = _Unit.Playlist.GetTracksByPlaylist(Convert.ToInt32(ddlPlaylist.SelectedValue));
                lRows = eRows.ToList();
            }
            gvPlaylist.DataSource = lRows;
            gvPlaylist.DataBind();
        }

        protected void btnPlaylistEditar_Click(object sender, EventArgs e)
        {
            if (ddlPlaylist.SelectedIndex > 0)
            {
                Response.Redirect("wfFormulario.aspx?a=" + ddlPlaylist.SelectedValue);
            }
            else
            {

            }
        }

        protected void gvPlaylist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        private void Playlist_Cargar()
        {
            List<Playlist> lItems = _Unit.Playlist.GetAll().ToList();
            if (lItems == null) { lItems = new List<Playlist>(); }
            lItems.Insert(0, new Playlist { PlaylistId= 0, Name="Seleccione" });
            ddlPlaylist.DataSource = lItems;
            ddlPlaylist.DataValueField = "PlaylistId";
            ddlPlaylist.DataTextField = "Name";
            ddlPlaylist.DataBind();
        }



    }
}