using System.Collections.Generic;
using System.Linq;

using Models;

namespace DataAccess
{
    public class PlaylistRepository
    {
        private ChinookContext _context;

        public PlaylistRepository()
        {
            _context = new ChinookContext();
        }

        public int Count()
        {
            return _context.Playlist.Count();
        }

        public IEnumerable<Playlist> GetLista()
        {
            return _context.Playlist;
        }

        public Playlist GetPlaylistPorId(int pId)
        {
            return _context.Playlist.Where(play => play.PlaylistId == pId).Take(1).FirstOrDefault();
        }

        public int Insert(string pName)
        {
            var oEntidad = new Playlist { Name = pName };
            _context.Playlist.Add(oEntidad);
            return _context.SaveChanges();
        }

        public int DeletePorId(int pId)
        {
            var oEntidad = new Playlist { PlaylistId = pId };
            _context.Playlist.Remove(oEntidad);
            return _context.SaveChanges();
        }
    }
}
