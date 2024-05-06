using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class EtatTest
    {
        private const string id = "id";
        private const string libelle = "libelle";
        private static Etat etat = new Etat(id, libelle);


        [TestMethod]
        public void etatTest()
        {
            Assert.AreEqual(id, etat.Id);
            Assert.AreEqual(libelle, etat.Libelle);
        }
    }
}
