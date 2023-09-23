using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PlaylistTrackRepository : Repository<PlaylistTrack>, IPlaylistTrackRepository
    {
        public PlaylistTrackRepository(ChinookContext pContext) : base(pContext)
        {
        }

        public PlaylistTrack GetByIDs(int pPlaylistId, int pTrackId)
        {
            return chinookContext.PlaylistTrack.FirstOrDefault(pt => pt.PlaylistId == pPlaylistId && pt.TrackId == pTrackId);
        }

        public ChinookContext chinookContext
        {
            get { return Context as ChinookContext; }
        }
    }
}
