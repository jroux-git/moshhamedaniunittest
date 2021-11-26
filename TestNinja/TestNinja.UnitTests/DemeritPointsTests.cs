using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{

    [TestFixture]
    public class DemeritPointsTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void Setup()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIdOutOfRange_ThrowArgumentOfOfRangeException(int speed)
        {
            // Assert
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(60, 0)]
        [TestCase(65, 0)]
        [TestCase(69, 0)]
        [TestCase(70, 1)]
        [TestCase(185, 24)]
        [TestCase(85, 4)]
        [TestCase(300, 47)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedDemeritPoints)
        {
            // Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDemeritPoints));
        }
        
    }
}
