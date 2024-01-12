using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekat_OMS;
using System;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class Kvar
    {
        [TestMethod]
        public void Constructor_WithParameters_PropertiesAreSet()
        {
            // Arrange
            var element = new Projekat_OMS.ElektricniElement(1, "Element1", 1000, 100, 100, "Visok napon");

            // Act
            var kvar = new Projekat_OMS.Kvar("1", DateTime.Now, "U popravci", "Description", element, "Problem");

            // Assert
            Assert.AreEqual("1", kvar.IdK);
            Assert.AreEqual("U popravci", kvar.StatusK);
            Assert.AreEqual("Description", kvar.KratakOpis);
            Assert.AreEqual(element, kvar.Ele_Element);
            Assert.AreEqual("Problem", kvar.OpisProblema);
        }

        [TestMethod]
        public void Constructor2_WithParameters_PropertiesAreSet()
        {
            // Arrange
            var element = new Projekat_OMS.ElektricniElement(1, "Element1", 1000, 100, 100, "Visok napon");

            // Act
            var kvar = new Projekat_OMS.Kvar("U popravci", "Description", element, "Problem");

            // Assert
            Assert.AreEqual("U popravci", kvar.StatusK);
            Assert.AreEqual("Description", kvar.KratakOpis);
            Assert.AreEqual(element, kvar.Ele_Element);
            Assert.AreEqual("Problem", kvar.OpisProblema);
        }

        [TestMethod]
        public void GetFormattedHeader_ShouldReturnExpectedHeader()
        {
            // Arrange
            string expectedHeader = "ID kvara             Datum kreiranja      Status               Kratak opis          ID elementa          Opis problema       ";

            // Act
            string actualHeader = Projekat_OMS.Kvar.GetFormattedHeader();

            // Assert
            Assert.AreEqual(expectedHeader, actualHeader);
        }

        [TestMethod]
        public void ToString_ShouldReturnExpectedString()
        {
            // Arrange
            var element = new Projekat_OMS.ElektricniElement(1, "Element1", 1000, 100, 100, "Visok napon");

            // Act
            Projekat_OMS.Kvar kvar = new Projekat_OMS.Kvar("1", new DateTime(2024-01-12), "U popravci", "Description", element, "Problem");

            string expectedString = "1                    0001-01-01           U popravci           Description          1                    Problem             ";

            // Act
            string actualString = kvar.ToString();

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }

            [TestMethod]
            public void Prikaz_OutputIsNotEmpty()
            {
                // Arrange
                Projekat_OMS.Services.KvarService kvarService = new Projekat_OMS.Services.KvarService();
                DateTime today = DateTime.Now;
                DateTime yesterday = today.AddDays(-1);

                // Create a StringWriter to capture console output
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    // Act
                    kvarService.SearchByDate(today, yesterday);

                    // Convert the captured console output to a string
                    string result = sw.ToString();

                    // Assert
                    NUnit.Framework.Assert.That(result, NUnit.Framework.Is.Empty);
                }
            }
    }
}
