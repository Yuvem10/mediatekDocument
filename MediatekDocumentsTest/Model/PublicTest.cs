using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class PublicTest
    {
        private const string id = "id";
        private const string libelle = "libelle";
        private static Public lepublic = new Public(id, libelle);


        [TestMethod]
        public void publicTest()
        {
            Assert.AreEqual(id, lepublic.Id);
            Assert.AreEqual(libelle, lepublic.Libelle);
        }
    }
}
