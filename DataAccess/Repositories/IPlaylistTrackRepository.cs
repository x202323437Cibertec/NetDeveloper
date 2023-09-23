using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPlaylistTrackRepository : IRepository<PlaylistTrack>
    {
        PlaylistTrack GetByIDs(int pPlaylistId, int pTrackId);
    }
}
