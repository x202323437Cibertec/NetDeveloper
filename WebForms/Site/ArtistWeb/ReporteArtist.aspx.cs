using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DataAccess;
using Models;
using System.Web.Services;

namespace WebForms.Site.ArtistWeb
{
    public partial class ReporteArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static ArtistResult arLista()
        {
            using (var unit = new UnitOfWork(new ChinookContext()))
            {
                var currentUserName = HttpContext.Current.User.Identity.Name;
                IEnumerable<Artist> artistas = unit.Artists.GetArtistsByStore();
                List<Artist> listaartistas = artistas.ToList();
                var result = new ArtistResult
                {
                    Artists = listaartistas,
                    CurrentUserName = currentUserName
                };
                return result;
            }
        }

        public class ArtistResult
        {
            public List<Artist> Artists { get; set; }
            public string CurrentUserName { get; set; }
        }

    }
}