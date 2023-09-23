using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Site.PlaylistWeb
{
    public partial class wfFormulario : System.Web.UI.Page
    {
        private UnitOfWork _Unit;

        public wfFormulario()
        {
            _Unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string strId = Request.QueryString["a"];
                hfPlaylistId.Value = strId;
                Playlist_Configurar();
                Track_Listar();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            // Preguntar si existe antes de agregar
            PlaylistTrack oEntidad1 = _Unit.PlaylistTrack.GetByIDs(Convert.ToInt32(hfPlaylistId.Value), Convert.ToInt32(ddlTrack.SelectedValue));
            if (oEntidad1 == null)
            {
                // Agregar track al playlist
                oEntidad1 = new PlaylistTrack() { PlaylistId = Convert.ToInt32(hfPlaylistId.Value), TrackId = Convert.ToInt32(ddlTrack.SelectedValue) };
                _Unit.PlaylistTrack.Add(oEntidad1);
                int int0 = _Unit.Complete();
                if (int0 > 0)
                {
                    Response.Redirect("wfListado.aspx");
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al agregar el track. Volver a intentar";
                }
            }
            else
            {
                lblMensaje.Text = "El track ya existe en la lista. Elegir otro";
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            // Preguntar si existe antes de quitar
            PlaylistTrack oEntidad1 = _Unit.PlaylistTrack.GetByIDs(Convert.ToInt32(hfPlaylistId.Value), Convert.ToInt32(ddlTrack.SelectedValue));
            if (oEntidad1 != null)
            {
                // Quitar track al playlist
                _Unit.PlaylistTrack.Remove(oEntidad1);
                int int0 = _Unit.Complete();
                if (int0 > 0)
                {
                    Response.Redirect("wfListado.aspx");
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error al quitar el track. Volver a intentar";
                }
            }
            else
            {
                lblMensaje.Text = "El track no existe en la lista. Elegir otro";
            }
        }

        private void Playlist_Configurar()
        {
            Playlist cEntidad = _Unit.Playlist.GetById(Convert.ToInt32(hfPlaylistId.Value));
            if (cEntidad != null)
            {
                lblPlaylist.Text = cEntidad.Name;
            }
            else
            {
                throw new Exception("No se obtuvo el PLAYLIST desde el listado. Intente nuevamente");
            }
        }

        private void Track_Listar()
        {
            List<Track> lItems = _Unit.Track.GetAllByMpegType();
            if (lItems == null) { lItems = new List<Track>(); }
            lItems.Insert(0, new Track { TrackId = 0, Name = "Seleccione" });
            ddlTrack.DataSource = lItems;
            ddlTrack.DataValueField = "TrackId";
            ddlTrack.DataTextField = "Name";
            ddlTrack.DataBind();
        }
    }
}