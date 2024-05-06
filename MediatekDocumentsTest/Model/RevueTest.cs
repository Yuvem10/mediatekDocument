using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediatekDocumentsTest.Model
{
    [TestClass]
    public class RevueTest
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
        private const string periodicite = "periodicite";
        private const int delaiMiseADipos = 1;

        private static Revue revue = new Revue(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon, periodicite, delaiMiseADipos);

        [TestMethod]
        public void revueTest()
        {
            Assert.AreEqual(id, revue.Id);
            Assert.AreEqual(titre, revue.Titre);
            Assert.AreEqual(image, revue.Image);
            Assert.AreEqual(idGenre, revue.IdGenre);
            Assert.AreEqual(genre, revue.Genre);
            Assert.AreEqual(idPublic, revue.IdPublic);
            Assert.AreEqual(idRayon, revue.IdRayon);
            Assert.AreEqual(rayon, revue.Rayon);
            Assert.AreEqual(periodicite, revue.Periodicite);
        }
    }
}
