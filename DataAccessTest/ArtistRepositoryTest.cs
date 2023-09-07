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
    public class ArtistRepositoryTest
    {
        private readonly ArtistRepository _entity;

        public ArtistRepositoryTest()
        {
            _entity = new ArtistRepository();
        }

        [TestMethod]
        public void Ejecucion_Diferida()
        {
            using (var context = new ChinookContext())
            {
                var resultado = from _artist in context.Artist where _artist.Name.StartsWith("A") select _artist;

                foreach (var artista in context.Artist)
                {
                    Assert.AreEqual(artista.ArtistId > 0,true);
                }
            }
        }

        [TestMethod]
        public void Ejecucion_Inmediata()
        {
            using (var context = new ChinookContext())
            {
                var resultado = (from _artist in context.Artist
                                 where _artist.Name.StartsWith("A")
                                 select _artist).Count();

                Assert.AreEqual(resultado > 0, true);
            }
        }

        [TestMethod]
        public void TestEf_Artist_Cantidad()
        {
            var count = _entity.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void TestEf_Artista_Lista()
        {
            var lisArtistas = _entity.GetListaArtista();
            Assert.AreEqual(lisArtistas.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_Artista_ListaSP()
        {
            var lisArtistas = _entity.GetListaArtistaStore();
            Assert.AreEqual(lisArtistas.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_InsertaArtista()
        {
            var intRes = _entity.InsertArtista("prueba entityFramework");
            Assert.AreEqual(intRes > 0, true);
        }

        [TestMethod]
        public void TestEf_BuscarPorId()
        {
            var objArtista = _entity.GetArtistaPorId(1);
            var vEncontrado = new Artist() { ArtistId = 1, Name = "AC/DC" };
            Assert.AreEqual(vEncontrado.ArtistId, objArtista.ArtistId);
            Assert.AreEqual(vEncontrado.Name, objArtista.Name);
        }

    }
}
