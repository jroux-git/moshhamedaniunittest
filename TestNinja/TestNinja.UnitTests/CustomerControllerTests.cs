using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotGound()
        {
            // Act
            var result = _controller.GetCustomer(0);

            // Assert
            // Must be a NotFound object
            Assert.That(result, Is.TypeOf<NotFound>());
            // OR
            // Can be a NotFound object or one of its derivatives
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            // Act
            var result = _controller.GetCustomer(1);

            // Assert
            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
