namespace CustomLinkedList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        [TestMethod]
        public void Count_NewListCreation_CountShouldBeZero()
        {
            // Arrange ans Act
            var list = new DynamicList<int>();
            var initialCount = list.Count;
            
            //Assert
            Assert.AreEqual(0, initialCount, "A newly created list should have a count of 0.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_SetInvalidIndex_ShouldThrow()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();

            // Act
            customList[3] = 2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_GetInvalidIndex_ShouldThrow()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();

            // Act
            var element  = customList[3];
        }


        [TestMethod]
        public void Add_CountShouldIncreaseWithCountOfAddedElements()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();

            // Act
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Assert
            Assert.AreEqual(3, customList.Count);
        }

        [TestMethod]
        public void Add_TestValueAndOrderOfTheElementAdded()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();

            // Act
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Assert
            Assert.AreEqual(1, customList[0]);
            Assert.AreEqual(2, customList[1]);
            Assert.AreEqual(3, customList[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_InvalidIndex_ShouldThrow()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();

            // Act
            customList.RemoveAt(2);
        }

        public void RemoveAt_ValidIndex_ShoudRemoveAndReturnElement()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Act
            var element = customList.RemoveAt(1);

            // Assert
            Assert.AreEqual(2, element, "Should return the removed element;");
            Assert.AreEqual(2, customList.Count, "The count should decrease");
        }

        [TestMethod]
        public void Remove_ElementFound_ShouldReturnElementIndex()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Act
           var elementIndex = customList.Remove(1);

            // Assert
            Assert.AreEqual(0, elementIndex, "Shoud return element index");
        }

        [TestMethod]
        public void Remove_ElementFound_ShouldDecreaseCount()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Act
            var elementIndex = customList.Remove(1);

            // Assert
            Assert.AreEqual(2, customList.Count, "The count should decrease");
        }

        [TestMethod]
        public void Remove_ElementNotFound_ShouldReturnMinus1()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Act
            var elementIndex = customList.Remove(10);

            // Assert
            Assert.AreEqual(-1, elementIndex, "Shoud return -1 when there is no such element");
        }

        [TestMethod]
        public void IndexOf_ElementFound_ShouldReturnElementIndex()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Act
           var index = customList.IndexOf(1);

            // Assert
            Assert.AreEqual(0, index, "Shoud return element index");
        }

        [TestMethod]
        public void IndexOf_ElementNotFound_ShouldReturnMinus1()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Act
            var index = customList.IndexOf(19);

            // Assert
            Assert.AreEqual(-1, index, "Shoud return -1 when element is not found");
        }

        [TestMethod]
        public void Conteins_ElementFound_ShouldReturnTrue()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Act
            var result = customList.Contains(1);

            // Assert
            Assert.IsTrue(result, "should return true when element is in the list");
        }

        [TestMethod]
        public void Conteins_ElementNotFound_ShouldReturnFalse()
        {
            // Arrange
            DynamicList<int> customList = new DynamicList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            // Act
            var result = customList.Contains(100);

            // Assert
            Assert.IsFalse(result, "should return false when element is not in the list");
        }
    }
}
