using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _service;

        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _service = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_MethodInjection_EmptyFile_ReturnError()
        {
            var service = new VideoService();

            var result = service.ReadVideoTitle_MethodInjection(new FakeFileReader());

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_PropertyInjection_EmptyFile_ReturnError()
        {
            var service = new VideoService();
            service.propFileReader = new FakeFileReader();

            var result = service.ReadVideoTitle_PropertyInjection();

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_ConstructorInjection_EmptyFile_ReturnError()
        {
            var service = new VideoService(new FakeFileReader());
            
            var result = service.ReadVideoTitle_ConstructorInjection();

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_ConstructorInjection_EmptyFileUsingMoq_ReturnError()
        {
            // Arrange
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            // Act
            var result = _service.ReadVideoTitle_ConstructorInjection();

            // Assert
            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }
    }
}
