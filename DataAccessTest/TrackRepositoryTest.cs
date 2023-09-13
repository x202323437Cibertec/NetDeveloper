using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;

namespace DataAccessTest
{
    [TestClass]
    public class TrackRepositoryTest
    {
        private readonly UnitOfWork _unit;

        public TrackRepositoryTest()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        [TestMethod]
        public void TestEf_Track_Cantidad()
        {
            var count = _unit.Track.Count();
            Assert.AreEqual(count > 0, true);
        }

        //[TestMethod]
        //public void TestEf_Track_Insertar()
        //{
        //    var nuevo = new Track { Name = "Desde el UOW" };
        //    _unit.Track.Add(nuevo);
        //    int intRes = _unit.Complete();
        //    var IdAlbum = _unit.Track.GetByName("Desde el UOW");
        //    Assert.AreEqual(IdAlbum.TrackId > 0, true);
        //}

        //[TestMethod]
        //public void TestEf_Track_BuscarPorId()
        //{
        //    var objTrack = _unit.Track.GetById(30);
        //    var vEncontrado = new Track() { TrackId = 30, Name = "Amazing" };
        //    Assert.AreEqual(vEncontrado.TrackId, objTrack.TrackId);
        //    Assert.AreEqual(vEncontrado.Name, objTrack.Name);
        //}

    }
}
