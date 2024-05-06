using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class GenreTest
    {
        private const string id = "id";
        private const string libelle = "libelle";
        private static Genre genre = new Genre(id, libelle);

        [TestMethod]
        public void genreTest()
        {
            Assert.AreEqual(id, genre.Id);
            Assert.AreEqual(libelle, genre.Libelle);
        }
    }
}
