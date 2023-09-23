using Models;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public IEnumerable<PlaylistTrackVM> GetTracksByPlaylist(int pPlaylistId)
        {
            var oSqlParId = new SqlParameter("@PI_PlaylistId", pPlaylistId);
            return chinookContext.Database.SqlQuery<PlaylistTrackVM>("dbo.GetTracksByPlaylist @PI_PlaylistId", oSqlParId);
        }

        public ChinookContext chinookContext
        {
            get { return Context as ChinookContext; }
        }
    }
}
