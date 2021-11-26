using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Push_ArgIsNull_ThrowArgumentIsNullException()
        {
            // Arrange
            var stack = new Stack<string>();

            // Act and Assert
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);    
        }

        [Test]
        public void Push_ValidArg_AddItemToStack()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("string");

            // Assert
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnsZero()
        {
            // Arrange
            var stack = new Stack<string>();

            // Assert
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            // Arrange
            var stack = new Stack<string>();

            // Assert
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithObjects_ReturnObjectOnTop()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("string");

            //Act
            var result = stack.Pop();

            // Assert
            Assert.That(result, Is.EqualTo("string"));
        }

        [Test]
        public void Pop_StackWithObjects_RemoveObjectOnTop()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("string");

            //Act
            var result = stack.Pop();

            // Assert
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            // Arrange
            var stack = new Stack<string>();
            
            // Act and Assert
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ReturnObjectOnTop()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("string");

            //Act
            var result = stack.Peek();

            // Assert
            Assert.That(result, Is.EqualTo("string"));
        }

        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveObjectOnTopOfStack()
        {
            // Arrange
            var stack = new Stack<string>();
            stack.Push("string");

            //Act
            stack.Peek();

            // Assert
            Assert.That(stack.Count, Is.EqualTo(1));
        }
    }
}
