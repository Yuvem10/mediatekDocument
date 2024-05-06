using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class SuiviTest
    {
        private const string statut = "statut";
       
        private static Suivi suivi = new Suivi(statut);

        [TestMethod]
        public void suiviTest()
        {
            Assert.AreEqual(statut, suivi.statut);
        }
    }
}
