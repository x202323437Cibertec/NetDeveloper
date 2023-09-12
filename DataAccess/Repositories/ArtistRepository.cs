using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArtistRepository: Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ChinookContext pContext) : base(pContext)
        { 
        
        }

        public IEnumerable<Artist> GetArtistsByStore()
        {
            return chinookContext.Database.SqlQuery<Artist>("GetListaArtista");
        }

        public Artist GetByName(string pName)
        {
            return chinookContext.Artist.FirstOrDefault(artista => artista.Name == pName);
        }

        public ChinookContext chinookContext
        {
            get { return Context as ChinookContext; }
        }

    }
}
