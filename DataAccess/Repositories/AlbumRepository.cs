using Models;
using System.Linq;

namespace DataAccess.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(ChinookContext pContext) : base(pContext)
        {
        }

        public Album GetByTitle(string pTitle)
        {
            return chinookContext.Album.FirstOrDefault(album1 => album1.Title == pTitle);
        }

        public ChinookContext chinookContext
        {
            get { return Context as ChinookContext; }
        }
    }
}
