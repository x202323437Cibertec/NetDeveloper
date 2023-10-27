using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using Xunit;
using FluentAssertions;

namespace DataAccessTest
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        private readonly UnitOfWork _unit;

        public ArtistRepositoryTest()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        [Fact]
        public void Artista_Pagina()
        {
            var pagina1 = _unit.Artists.GetArtistPage(1, 10).ToList();
            var pagina2 = _unit.Artists.GetArtistPage(2, 10).ToList();
            pagina1.Count().Should().Be(pagina2.Count());
            pagina1[1].Name.Should().NotBe(pagina2[1].Name);
        }

        [Fact]
        public void Ejecucion_Diferida()
        {
            using (var context = new ChinookContext())
            {
                var resultado = from _artist in context.Artist where _artist.Name.StartsWith("A") select _artist;

                foreach (var artista in context.Artist)
                {
                    //Assert.AreEqual(artista.ArtistId > 0, true);
                    artista.ArtistId.Should().BeGreaterThan(0);
                }
            }
        }

        [Fact]
        public void Ejecucion_Inmediata()
        {
            using (var context = new ChinookContext())
            {
                var resultado = (from _artist in context.Artist
                                 where _artist.Name.StartsWith("A")
                                 select _artist).Count();
                //Assert.AreEqual(resultado > 0, true);
                resultado.Should().BeGreaterThan(0);
            }
        }

        [Fact]
        public void TestEf_Artist_Cantidad()
        {
            var count = _unit.Artists.Count();
            //Assert.AreEqual(count > 0, true);
            count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void TestEf_Artista_Lista()
        {
            var lisArtistas = _unit.Artists.GetAll();
            //Assert.AreEqual(lisArtistas.Count() > 0, true);
            lisArtistas.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void TestEf_Artista_ListaSP()
        {
            var lisArtistas = _unit.Artists.GetArtistsByStore();
            //Assert.AreEqual(lisArtistas.Count() > 0, true);
            lisArtistas.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void TestEf_InsertaArtista()
        {
            var nuevo = new Artist { Name = "Desde el UOW" };
            _unit.Artists.Add(nuevo);
            int intRes = _unit.Complete();
            var cArtista = _unit.Artists.GetByName("Desde el UOW");
            //Assert.AreEqual(cArtista.ArtistId > 0, true);
            //Assert.AreEqual(cArtista.Name, "Desde el UOW");
            cArtista.ArtistId.Should().BeGreaterThan(0);
            cArtista.Name.Should().Be("Desde el UOW");
        }

        [Fact]
        public void TestEf_BuscarPorId()
        {
            var objArtista = _unit.Artists.GetById(1);
            var vEncontrado = new Artist() { ArtistId = 1, Name = "AC/DC" };
            //Assert.AreEqual(vEncontrado.ArtistId, objArtista.ArtistId);
            //Assert.AreEqual(vEncontrado.Name, objArtista.Name);
            vEncontrado.ArtistId.Should().Be(objArtista.ArtistId);
            vEncontrado.Name.Should().Be(objArtista.Name);
        }

    }
}
