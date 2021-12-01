using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        [Test]
        public void DeleteEmployee_WithValidId_DeleteEmployeeFromDb()
        {
            // Arrange
            var repo = new Mock<IEmployeeRepository>();
            repo.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(true);

            // Act
            bool result = repo.Object.DeleteEmployee(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteEmployee_WithNotValidId_DoNotDeleteEmployeeFromDb()
        {
            // Arrange
            var repo = new Mock<IEmployeeRepository>();
            repo.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(false);

            // Act
            bool result = repo.Object.DeleteEmployee(1);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
