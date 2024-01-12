using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class ElektricniTip
    {
        [TestMethod]
        public void Konstruktor_PostavljaVrednostiSvojstava()
        {
            // Priprema
            int ocekivaniIdET = 1;
            string ocekivaniNazivET = "TestElektricniTip";

            // Izvršenje
            var elektricniTip = new Projekat_OMS.Model.ElektricniTip(ocekivaniIdET, ocekivaniNazivET);

            // Provera
            Assert.AreEqual(ocekivaniIdET, elektricniTip.IdET);
            Assert.AreEqual(ocekivaniNazivET, elektricniTip.NazivET);
        }
    }
}
