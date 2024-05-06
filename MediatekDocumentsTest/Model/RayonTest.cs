using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class RayonTest
    {
        private const string id = "id";
        private const string libelle = "libelle";
        private static Rayon rayon = new Rayon(id, libelle);

        [TestMethod]
        public void rayonTest()
        {
            Assert.AreEqual(id, rayon.Id);
            Assert.AreEqual(libelle, rayon.Libelle);
        }
    }
}
