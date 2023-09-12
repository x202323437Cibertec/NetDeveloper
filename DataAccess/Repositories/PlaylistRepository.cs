using Models;
using System.Linq;

namespace DataAccess.Repositories
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(ChinookContext pContext) : base(pContext)
        {
        }

        public Playlist GetByName(string pName)
        {
            return chinookContext.Playlist.FirstOrDefault(playl => playl.Name == pName);
        }
        public ChinookContext chinookContext
        {
            get { return Context as ChinookContext; }
        }
    }
}
