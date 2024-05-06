using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class LivreTest
    {
        private const string id = "id";
        private const string titre = "titre";
        private const string image = "image";
        private const string isbn = "isbn";
        private const string auteur = "auteur";
        private const string collection = "collection";
        private const string idgenre = "idGenre";
        private const string genre = "genre";
        private const string idpublic = "idPublic";
        private const string lepublic = "lePublic";
        private const string idrayon = "idRayon";
        private const string rayon = "rayon";

        private static Livre livre = new Livre(id, titre, image, isbn, auteur, collection, idgenre, genre, idpublic, lepublic, idrayon, rayon);


        [TestMethod]
        public void livreTest()
        {
            Assert.AreEqual(id, livre.Id);
            Assert.AreEqual(titre, livre.Titre);
            Assert.AreEqual(image, livre.Image);
            Assert.AreEqual(isbn, livre.Isbn);
            Assert.AreEqual(auteur, livre.Auteur);
            Assert.AreEqual(collection, livre.Collection);
            Assert.AreEqual(idgenre, livre.IdGenre);
            Assert.AreEqual(genre, livre.Genre);
            Assert.AreEqual(idpublic, livre.IdPublic);
            Assert.AreEqual(lepublic, livre.Public);
            Assert.AreEqual(idrayon, livre.IdRayon);
            Assert.AreEqual(rayon, livre.Rayon);
        }
    }
}
