using Models;
using System.Linq;

namespace DataAccess.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(ChinookContext pContext) : base(pContext)
        {
        }

        public Track GetByName(string pName)
        {
            return chinookContext.Track.FirstOrDefault(tra => tra.Name == pName);
        }
        public ChinookContext chinookContext
        {
            get { return Context as ChinookContext; }
        }
    }
}
