using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;

namespace DataAccessTest
{
    [TestClass]
    public class PlaylistRepositoryTest
    {
        private readonly UnitOfWork _unit;

        public PlaylistRepositoryTest()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        [TestMethod]
        public void TestEf_Playlist_Cantidad()
        {
            var count = _unit.Playlist.Count();
            Assert.AreEqual(count > 0, true);
        }

        //[TestMethod]
        //public void TestEf_Playlist_Lista()
        //{
        //    var lista = _entity.GetLista();
        //    Assert.AreEqual(lista.Count() > 0, true);
        //}

        [TestMethod]
        public void TestEf_Playlist_Insertar()
        {
            var nuevo = new Playlist { Name = "Desde el UOW" };
            _unit.Playlist.Add(nuevo);
            int intRes = _unit.Complete();
            var IdAlbum = _unit.Playlist.GetByName("Desde el UOW");
            Assert.AreEqual(IdAlbum.PlaylistId > 0, true);
        }

        [TestMethod]
        public void TestEf_Playlist_BuscarPorId()
        {
            var objPlay = _unit.Playlist.GetById(6);
            var vEncontrado = new Playlist() { PlaylistId = 6, Name = "Audiobooks" };
            Assert.AreEqual(vEncontrado.PlaylistId, objPlay.PlaylistId);
            Assert.AreEqual(vEncontrado.Name, objPlay.Name);
        }

    }
}
