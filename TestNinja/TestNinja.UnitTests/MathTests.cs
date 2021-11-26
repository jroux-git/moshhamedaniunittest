using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math { get; set; }

        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            // Act
            var result = _math.GetOddNumbers(5);

            // Assert
            Assert.That(result, Is.Not.Empty);

            // Testing items in collection
            Assert.That(result.Count(), Is.EqualTo(3));
            // OR check that it contains the elements you expect
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));
            // OR simpler
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5}));
        }
    }
}
