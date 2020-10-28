using System;
using CardSorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTests
{
    [TestClass]
    public class ValueComparerTests
    {
        [TestMethod]
        public void CompareReturnsZeroWhenValuesAreEqual()
        {
            var sut = new ValueComparer();
            var result = sut.Compare('2', '2');
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareThrowsExceptionWhenFirstArgIsNotValue()
        {
            var sut = new ValueComparer();
            Assert.ThrowsException<ArgumentException>(() => sut.Compare('x', '2'));
        }

        [TestMethod]
        public void CompareThrowsExceptionWhenSecondArgIsNotValue()
        {
            var sut = new ValueComparer();
            Assert.ThrowsException<ArgumentException>(() => sut.Compare('2', 'x'));
        }

        [TestMethod]
        public void CompareReturnsPositiveWhenFirstValueIsHigher()
        {
            var sut = new ValueComparer();
            var result = sut.Compare('3', '2');
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareReturnsPositiveWhenFirstValueIsLower()
        {
            var sut = new ValueComparer();
            var result = sut.Compare('2', '3');
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void ValuesAreInCorrectOrderAscending()
        {
            var sut = new ValueComparer();
            var result = sut.Compare('2', '3');
            Assert.IsTrue(result < 0);
            result = sut.Compare('3', '4');
            Assert.IsTrue(result < 0);
            result = sut.Compare('4', '5');
            Assert.IsTrue(result < 0);
            result = sut.Compare('5', '6');
            Assert.IsTrue(result < 0);
            result = sut.Compare('6', '7');
            Assert.IsTrue(result < 0);
            result = sut.Compare('7', '8');
            Assert.IsTrue(result < 0);
            result = sut.Compare('8', '9');
            Assert.IsTrue(result < 0);
            result = sut.Compare('9', 'J');
            Assert.IsTrue(result < 0);
            result = sut.Compare('J', 'Q');
            Assert.IsTrue(result < 0);
            result = sut.Compare('Q', 'K');
            Assert.IsTrue(result < 0);
            result = sut.Compare('K', 'A');
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void ValuesAreInCorrectOrderDescending()
        {
            var sut = new ValueComparer();
            var result = sut.Compare('A', 'K');
            Assert.IsTrue(result > 0);
            result = sut.Compare('K', 'Q');
            Assert.IsTrue(result > 0);
            result = sut.Compare('Q', 'J');
            Assert.IsTrue(result > 0);
            result = sut.Compare('J', '9');
            Assert.IsTrue(result > 0);
            result = sut.Compare('9', '8');
            Assert.IsTrue(result > 0);
            result = sut.Compare('8', '7');
            Assert.IsTrue(result > 0);
            result = sut.Compare('7', '6');
            Assert.IsTrue(result > 0);
            result = sut.Compare('6', '5');
            Assert.IsTrue(result > 0);
            result = sut.Compare('5', '4');
            Assert.IsTrue(result > 0);
            result = sut.Compare('4', '3');
            Assert.IsTrue(result > 0);
            result = sut.Compare('3', '2');
            Assert.IsTrue(result > 0);
        }
    }
}
