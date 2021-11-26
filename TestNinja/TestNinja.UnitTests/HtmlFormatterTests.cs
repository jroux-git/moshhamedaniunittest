using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        private HtmlFormatter _htmlFormatter;

        [OneTimeSetUp]
        public void Setup()
        {
            _htmlFormatter = new HtmlFormatter();
        }

        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            // Act
            var result = _htmlFormatter.FormatAsBold("abc");

            // Assert
            // Remember string tests are case senstive in nUnit
            // Very Specific
            Assert.That(result, Is.EqualTo("<strong>abc</strong>"));

            // More general
            Assert.That(result, Does.StartWith("<strong>"));

            // Possible alternative
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
        }
    }
}
