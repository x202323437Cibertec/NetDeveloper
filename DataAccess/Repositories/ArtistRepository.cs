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

        public Artist GetByName(string pName)
        {
            return chinookContext.Artist.FirstOrDefault(artista => artista.Name == pName);
        }

        public IEnumerable<Artist> GetArtistsByStore()
        {
            return chinookContext.Database.SqlQuery<Artist>("GetListaArtista");
        }

        public IEnumerable<Artist> GetArtistPage(int pPageIndex, int pPageSize)
        {
            var query = chinookContext.Artist.OrderBy(a => a.ArtistId).Skip((pPageIndex - 1) * pPageSize).Take(pPageSize);
            return query.ToList();
        }

        public int count()
        {
            throw new NotImplementedException();
        }

        public ChinookContext chinookContext
        {
            get { return Context as ChinookContext; }
        }

    }
}
