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
        private readonly PlaylistRepository _entity;

        public PlaylistRepositoryTest()
        {
            _entity = new PlaylistRepository();
        }

        [TestMethod]
        public void TestEf_Playlist_Cantidad()
        {
            var count = _entity.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void TestEf_Playlist_Lista()
        {
            var lista = _entity.GetLista();
            Assert.AreEqual(lista.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_Playlist_Insertar()
        {
            var intRes = _entity.Insert("prueba PLAYLIST EF");
            Assert.AreEqual(intRes > 0, true);
        }

        [TestMethod]
        public void TestEf_Playlist_BuscarPorId()
        {
            var objPlay = _entity.GetPlaylistPorId(1);
            var vEncontrado = new Playlist() { PlaylistId = 1, Name = "Music" };
            Assert.AreEqual(vEncontrado.PlaylistId, objPlay.PlaylistId);
            Assert.AreEqual(vEncontrado.Name, objPlay.Name);
        }

    }
}
