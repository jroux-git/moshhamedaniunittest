using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class ErrorLoggerTests
    {
        private ErrorLogger _logger { get; set; }

        [SetUp]
        public void Setup()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            // Act
            _logger.Log("This is an error");

            // Assert
            Assert.That(_logger.LastError, Is.EqualTo("This is an error"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ShouldThroughArgumentNullException(string error)
        {
            // Assert
            // Have to create a delegate to test exceptions
            Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);
        }
    }
}
