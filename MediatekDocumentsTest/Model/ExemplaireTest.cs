using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class ExemplaireTest
    {
        private const int numero = 1;
        private const string photo = "photo";
        private static DateTime dateAchat = new DateTime(2021, 1, 1);
        private const string idEtat = "idEtat";
        private const string idDocument = "idDocument";
        private static Exemplaire exemplaire = new Exemplaire(numero, dateAchat, photo, idEtat, idDocument);


        [TestMethod]
        public void exemplaireTest()
        {
            Assert.AreEqual(numero, exemplaire.Numero);
            Assert.AreEqual(photo, exemplaire.Photo);
            Assert.AreEqual(dateAchat, exemplaire.DateAchat);
            Assert.AreEqual(idEtat, exemplaire.IdEtat);
            Assert.AreEqual(idDocument, exemplaire.Id);
        }
    }
}
