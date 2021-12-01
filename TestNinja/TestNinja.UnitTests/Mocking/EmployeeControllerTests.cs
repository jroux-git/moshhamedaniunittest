using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Mocking;
using Moq;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]    
    public class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_WithValidId_DeleteEmployeeFromDb()
        {
            // Arrange
            var repo = new Mock<IEmployeeRepository>();
            var employeeController = new EmployeeController(repo.Object);
            repo.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(true);

            // Act
            var reresponsesult = employeeController.DeleteEmployee(1);

            // Assert
            repo.Verify(r => r.DeleteEmployee(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void DeleteEmployee_WithValidId_RedirectOccured()
        {
            // Arrange
            var repo = new Mock<IEmployeeRepository>();
            var employeeController = new EmployeeController(repo.Object);
            repo.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(true);

            // Act
            var response = employeeController.DeleteEmployee(1);

            // Assert
            Assert.That(response, Is.TypeOf<RedirectResult>());
        }

        [Test]
        public void DeleteEmployee_WithInvalidId_DoNotDeleteEmployeeFromDb()
        {
            // Arrange
            var repo = new Mock<IEmployeeRepository>();
            var employeeController = new EmployeeController(repo.Object);
            repo.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(false);

            // Act
            var result = employeeController.DeleteEmployee(1);

            // Assert
            repo.Verify(r => r.DeleteEmployee(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void DeleteEmployee_WithInvalidId_NotFoundResultReturned()
        {
            // Arrange
            var repo = new Mock<IEmployeeRepository>();
            var employeeController = new EmployeeController(repo.Object);
            repo.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Returns(false);

            // Act
            var result = employeeController.DeleteEmployee(1);

            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}
