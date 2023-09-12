//using System.Collections.Generic;
//using System.Linq;

//using Models;

//namespace DataAccess
//{
//    public class ArtistRepository
//    {
//        private ChinookContext _context;

//        public ArtistRepository()
//        {
//            _context = new ChinookContext();
//        }

//        public int Count()
//        {
//            return _context.Artist.Count();
//        }

//        public IEnumerable<Artist> GetListaArtista()
//        {
//            return _context.Artist;
//        }

//        public IEnumerable<Artist> GetListaArtistaStore()
//        {
//            return _context.Database.SqlQuery<Artist>("GetListaArtista");
//        }

//        public Artist GetArtistaPorId(int pId)
//        {
//            //return _context.Artist.FirstOrDefault(x => x.ArtistId == pId);
//            return _context.Artist.Where(artist => artist.ArtistId == pId).Take(1).FirstOrDefault();
//        }

//        public int InsertArtista(string pName)
//        {
//            var oEntidad = new Artist { Name = pName };
//            _context.Artist.Add(oEntidad);
//            return _context.SaveChanges();
//        }

//        public int DeleteArtistaPorId(int pId)
//        {
//            var oEntidad = new Artist { ArtistId = pId };
//            _context.Artist.Remove(oEntidad);
//            return _context.SaveChanges();
//        }

//    }
//}
