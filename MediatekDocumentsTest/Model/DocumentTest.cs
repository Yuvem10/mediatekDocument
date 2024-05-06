using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class DocumentTest
    {
        private const string id = "id";
        private const string titre = "titre";
        private const string image = "image";
        private const string idGenre = "idGenre";
        private const string genre = "genre";
        private const string idPublic = "idPublic";
        private const string lePublic = "lePublic";
        private const string idRayon = "idRayon";
        private const string rayon = "rayon";
        private static Document document = new Document(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        [TestMethod]
        public void documentTest()
        {
            Assert.AreEqual(id, document.Id);
            Assert.AreEqual(titre, document.Titre);
            Assert.AreEqual(image, document.Image);
            Assert.AreEqual(idGenre, document.IdGenre);
            Assert.AreEqual(genre, document.Genre);
            Assert.AreEqual(idPublic, document.IdPublic);
            Assert.AreEqual(lePublic, document.Public);
            Assert.AreEqual(idRayon, document.IdRayon);
            Assert.AreEqual(rayon, document.Rayon);
        }
    }
}
