using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Projekat_OMS.Services;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ElektricniElement
    {
        [TestMethod]
        public void Konstruktor_PostavljaVrednostiSvojstava()
        {
            // Priprema
            int ocekivaniID = 1;
            string ocekivaniNaziv = "TestElement";
            int ocekivaniTip = 2;
            int ocekivaniX = 10;
            int ocekivaniY = 20;
            string ocekivaniNaponskiNivo = "Visoki";

            // Izvršenje
            var elektricniElement = new Projekat_OMS.ElektricniElement(ocekivaniID, ocekivaniNaziv, ocekivaniTip, ocekivaniX, ocekivaniY, ocekivaniNaponskiNivo);

            // Provera
            Assert.AreEqual(ocekivaniID, elektricniElement.IdEE);
            Assert.AreEqual(ocekivaniNaziv, elektricniElement.NazivEE);
            Assert.AreEqual(ocekivaniTip, elektricniElement.TipEE);
            Assert.AreEqual(ocekivaniX, elektricniElement.X);
            Assert.AreEqual(ocekivaniY, elektricniElement.Y);
            Assert.AreEqual(ocekivaniNaponskiNivo, elektricniElement.NaponskiNivoEE);
        }

        [TestMethod]
        public void Konstruktor2_PostavljaVrednostiSvojstava()
        {
            // Priprema
            string ocekivaniNaziv = "TestElement";
            int ocekivaniTip = 2;
            int ocekivaniX = 10;
            int ocekivaniY = 20;
            string ocekivaniNaponskiNivo = "Visoki";

            // Izvršenje
            var elektricniElement = new Projekat_OMS.ElektricniElement(ocekivaniNaziv, ocekivaniTip, ocekivaniX, ocekivaniY, ocekivaniNaponskiNivo);

            // Provera
            Assert.AreEqual(ocekivaniNaziv, elektricniElement.NazivEE);
            Assert.AreEqual(ocekivaniTip, elektricniElement.TipEE);
            Assert.AreEqual(ocekivaniX, elektricniElement.X);
            Assert.AreEqual(ocekivaniY, elektricniElement.Y);
            Assert.AreEqual(ocekivaniNaponskiNivo, elektricniElement.NaponskiNivoEE);
        }

        [TestMethod]
        public void GetFormattedHeader_VracaIspravanFormat()
        {
            // Izvršenje
            string rezultat = Projekat_OMS.ElektricniElement.GetFormattedHeader();

            // Provera
            string ocekivaniFormat = "IDEE     NazivEE              TipEE_ID   X     Y     NaponskiNivoEE      ";
            Assert.AreEqual(ocekivaniFormat, rezultat);
        }

        [TestMethod]
        public void ToString_VracaIspravanFormat()
        {
            // Priprema
            int ocekivaniId = 1;
            string ocekivaniNaziv = "TestElement";
            int ocekivaniTip = 2;
            int ocekivaniX = 10;
            int ocekivaniY = 20;
            string ocekivaniNaponskiNivo = "Visoki";

            var elektricniElement = new Projekat_OMS.ElektricniElement(ocekivaniId, ocekivaniNaziv, ocekivaniTip, ocekivaniX, ocekivaniY, ocekivaniNaponskiNivo);

            // Izvršenje
            string rezultat = elektricniElement.ToString();

            // Provera
            string ocekivaniFormat = $"{ocekivaniId,-8} {ocekivaniNaziv,-20} {ocekivaniTip,-10} {ocekivaniX,-5} {ocekivaniY,-5} {ocekivaniNaponskiNivo,-20}";
            Assert.AreEqual(ocekivaniFormat, rezultat);
        }
    }
}
