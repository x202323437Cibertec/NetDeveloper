using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataAccessTest
{
    [TestClass]
    public class AlbumRepositoryTest
    {
        private readonly UnitOfWork _unit;

        public AlbumRepositoryTest()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        [TestMethod]
        public void TestEf_Album_Cantidad()
        {
            var count = _unit.Album.Count();
            Assert.AreEqual(count > 0, true);
        }

    }
}
