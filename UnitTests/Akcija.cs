using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class Akcija
    {
        [TestMethod]
        public void Konstruktor_PostavljaVrednostiSvojstava()
        {
            // Priprema
            int ocekivaniIdA = 1;
            string ocekivaniIdK = "TestKorisnik";
            string ocekivaniDatumAkcije = "2024-01-12";
            string ocekivaniOpisA = "Test akcija";

            // Izvršenje
            var akcija = new Projekat_OMS.Akcija(ocekivaniIdA, ocekivaniIdK, ocekivaniDatumAkcije, ocekivaniOpisA);

            // Provera
            Assert.AreEqual(ocekivaniIdA, akcija.IdA);
            Assert.AreEqual(ocekivaniIdK, akcija.IdK);
            Assert.AreEqual(ocekivaniDatumAkcije, akcija.DatumAkcije);
            Assert.AreEqual(ocekivaniOpisA, akcija.OpisA);
        }

        [TestMethod]
        public void Konstruktor2_PostavljaVrednostiSvojstava()
        {
            // Priprema
            string ocekivaniIdK = "TestKorisnik";
            string ocekivaniOpisA = "Test akcija";

            // Izvršenje
            var akcija = new Projekat_OMS.Akcija(ocekivaniIdK, ocekivaniOpisA);

            // Provera
            Assert.AreEqual(ocekivaniIdK, akcija.IdK);
            Assert.AreEqual(ocekivaniOpisA, akcija.OpisA);
        }
    }
}
