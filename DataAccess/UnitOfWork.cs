using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChinookContext _context;

        public UnitOfWork(ChinookContext pContext)
        {
            _context = pContext;
            Artists = new ArtistRepository(_context);
            Album = new AlbumRepository(pContext);
            Playlist = new PlaylistRepository(pContext);
            Track = new TrackRepository(pContext);
            Customers = new CustomerRepository(pContext);
        }

        public IArtistRepository Artists { get; private set; }

        public IAlbumRepository Album { get; private set; }

        public IPlaylistRepository Playlist { get; private set; }

        public ITrackRepository Track { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
