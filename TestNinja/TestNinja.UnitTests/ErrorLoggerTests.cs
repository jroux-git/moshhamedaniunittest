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
    }
}
