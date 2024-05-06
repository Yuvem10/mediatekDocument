using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class CategorieTest
    {
        private const string id = "id";
        private const string nom = "nom";
        private static readonly Categorie categorie = new Categorie(id, nom);

        [TestMethod]
        public void categorieTest()
        {
            Assert.AreEqual(id, categorie.Id);
            Assert.AreEqual(nom, categorie.Libelle);
        }
    }
}
