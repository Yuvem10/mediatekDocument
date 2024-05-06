using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class CommandeTest
    {
        private const string id = "id";
        private static readonly DateTime dateCommande = DateTime.Now;
        private const float montant = 10.0f;
        private static readonly Commande commande = new Commande(id, dateCommande, montant);

        [TestMethod]
        public void commandeTest()
        {
            Assert.AreEqual(id, commande.id);
            Assert.AreEqual(dateCommande, commande.dateCommande);
            Assert.AreEqual(montant, commande.montant);
        }
    }
}
