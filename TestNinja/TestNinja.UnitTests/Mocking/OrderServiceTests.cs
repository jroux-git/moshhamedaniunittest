using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IStorage> _storage;
        private OrderService _service;

        [SetUp]
        public void Setup()
        {
            _storage = new Mock<IStorage>();
            _service = new OrderService(_storage.Object);
        }

        [Test]
        public void PlaceOrder_WhenCalled_ShouldStoreOrder()
        {
            // Arrange
            var order = new Order();

            // Act
            var result = _service.PlaceOrder(order);

            // Assert
            _storage.Verify(s => s.Store(order), Times.Exactly(1));
        }
    }
}
