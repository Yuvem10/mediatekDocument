using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;
using MediaTekDocuments;


namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class DvdTest
    {
        private const string id = "id";
        private const string titre = "titre";
        private const string image = "image";
        private const int duree = 120;
        private const string realisateur = "realisateur";
        private const string synopsis = "synopsis";
        private const string idGenre = "idGenre";
        private const string genre = "genre";
        private const string idPublic = "idPublic";
        private const string lePublic = "lePublic";
        private const string idRayon = "idRayon";
        private const string rayon = "rayon";
        private static Dvd dvd = new Dvd(id, titre, image, duree, realisateur, synopsis, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        [TestMethod]
        public void dvdTest()
        {
            Assert.AreEqual(id, dvd.Id);
            Assert.AreEqual(titre, dvd.Titre);
            Assert.AreEqual(image, dvd.Image);
            Assert.AreEqual(duree, dvd.Duree);
            Assert.AreEqual(realisateur, dvd.Realisateur);
            Assert.AreEqual(synopsis, dvd.Synopsis);
            Assert.AreEqual(idGenre, dvd.IdGenre);
            Assert.AreEqual(genre, dvd.Genre);
            Assert.AreEqual(idPublic, dvd.IdPublic);
            Assert.AreEqual(lePublic, dvd.Public);
            Assert.AreEqual(idRayon, dvd.IdRayon);
            Assert.AreEqual(rayon, dvd.Rayon);
        }
    }
}
