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
    public class FizzBuzzTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        public void GetOutput_NumberIsDvisibleByThreeAndFive_ReturnFizzBuzz(int num)
        {
            // Act
            var result = FizzBuzz.GetOutput(num);

            // Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        public void GetOutput_NumberIsDvisibleByThreeAndNotFive_ReturnFizz(int num)
        {
            // Act
            var result = FizzBuzz.GetOutput(num);

            // Assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public void GetOutput_NumberIsDvisibleByFiveNotThree_ReturnBuzz(int num)
        {
            // Act
            var result = FizzBuzz.GetOutput(num);

            // Assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(11)]
        public void GetOutput_NumberIsNotDvisibleByFiveOrThree_ReturnNumber(int num)
        {
            // Act
            var result = FizzBuzz.GetOutput(num);

            // Assert
            Assert.That(result, Is.EqualTo(num.ToString()));
        }

    }
}
