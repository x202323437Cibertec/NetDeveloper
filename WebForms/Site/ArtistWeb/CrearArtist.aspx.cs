using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.App_Code;

namespace WebForms.Site.ArtistWeb
{ 
    public partial class CrearArtist : BasePage
    {
        private UnitOfWork _Unit;

        public CrearArtist()
        {
            _Unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                VerifyUser();
                IsUserInRole("ADMIN");
            }
        }

        //protected void btnCrear_Click(object sender, EventArgs e)
        //{
        //    var artista = new Artist { Name=txtName.Text };
        //    _Unit.Artists.Add(artista);
        //    if (_Unit.Complete() > 0)
        //    {
        //        Response.Redirect("ListaArtist.aspx");
        //    }
        //}

        [WebMethod]
        public static bool InsertArtist(string pName)
        {
            var artist = new Artist { Name = pName };
            using (var unit = new UnitOfWork(new ChinookContext()))
            {
                unit.Artists.Add(artist);
                return unit.Complete() > 0;
            }
        }

    }
}