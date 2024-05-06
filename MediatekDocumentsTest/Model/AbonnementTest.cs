using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class AbonnementTest
    {
        private const string id = "id";
        private static readonly DateTime dateCommande = DateTime.Now;
        private const float montant = 10.0f;
        private static readonly DateTime dateFinAbonnement = DateTime.Now;
        private const string idRevue = "idRevue";
        private static readonly Abonnement abonnement = new Abonnement(id,dateCommande, montant, dateFinAbonnement, idRevue);


        [TestMethod]
        public void abonnementTest()
        {
            Assert.AreEqual(id, abonnement.id);
            Assert.AreEqual(dateCommande, abonnement.dateCommande);
            Assert.AreEqual(montant, abonnement.montant);
            Assert.AreEqual(dateFinAbonnement, abonnement.dateFinAbonnement);
            Assert.AreEqual(idRevue, abonnement.idRevue);
        }
    }
}
