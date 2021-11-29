using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper installerHelper;

        [SetUp]
        public void Setup()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_WhenThereIsAnError_ReturnFalse()
        {
            // Arrange
            _fileDownloader.Setup(x => x.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            // Act
            var result = installerHelper.DownloadInstaller("custommer", "installer");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_WhenNoError_ReturnTrue()
        {
            // Arrange
            // not necessary here because by default it will not throw an exception

            // Act
            var result = installerHelper.DownloadInstaller("custommer", "installer");

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
