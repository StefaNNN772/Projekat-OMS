using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Projekat_OMS;
using Projekat_OMS.Services;
using Projekat_OMS.UIHandler.Implementation;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class Dokument
    {
        [TestMethod]
        public void KreirajExcel_WhenValidIdkProvided_ShouldCallDokumentMethod()
        {
            // Arrange
            var kvarServiceMock = new Mock<KvarService>();

            var kvarList = new List<Projekat_OMS.Kvar>
            {
                // Add sample Kvar instances for testing
                new Projekat_OMS.Kvar("20240112005051_0001", DateTime.Parse("2024-01-12"), "U popravci", "dwadwwda", new Projekat_OMS.ElektricniElement(200, "Element1", 1000, 100, 100, "Visok napon"), "dwawdaawdwa" )
                // Add more instances as needed
            };

            kvarServiceMock.Setup(mock => mock.FindAll()).Returns(kvarList);
            kvarServiceMock.Setup(mock => mock.FindById(It.IsAny<string>())).Returns((string id) => kvarList.Find(kvar => kvar.IdK == id));

            var kreiranjeDokumenta = new KreiranjeDokumenta();
            //kreiranjeDokumenta.KvarService = kvarServiceMock.Object;

            // Mock Console.ReadLine
            var idkInput = "20240112005051_0001";
            using (var stringReader = new StringReader(idkInput))
            {
                Console.SetIn(stringReader);

                // Act
                kreiranjeDokumenta.KreirajExcel();

                // Assert
                kvarServiceMock.Verify(mock => mock.Dokument(It.IsAny<string>()), Times.Once);
            }
        }
    }
}
