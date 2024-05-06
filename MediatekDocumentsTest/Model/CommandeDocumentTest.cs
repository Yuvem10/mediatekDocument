using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class CommandeDocumentTest
    {
        private const string id = "id";
        private static readonly DateTime dateCommande = DateTime.Now;
        private const float montant = 10.0f;
        private const int nbExemplaire = 1;
        private const string idLivreDvd = "idLivreDvd";
        private const string statut = "Livrée";
        CommandeDocument commandeDocument = new CommandeDocument(id, dateCommande, montant, nbExemplaire, idLivreDvd, statut);


        [TestMethod]
        public void commandeDocumentTest()
        {
            Assert.AreEqual(id, commandeDocument.id);
            Assert.AreEqual(dateCommande, commandeDocument.dateCommande);
            Assert.AreEqual(montant, commandeDocument.montant);
            Assert.AreEqual(nbExemplaire, commandeDocument.nbExemplaire);
            Assert.AreEqual(idLivreDvd, commandeDocument.idLivreDvd);
            Assert.AreEqual(statut, commandeDocument.statut);
        }
    }
}
