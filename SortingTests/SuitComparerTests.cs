using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardSorting;

namespace SortingTests
{
    [TestClass]
    public class SuitComparerTests
    {
        [TestMethod]
        public void CompareReturnsZeroWhenSuitsAreEqual()
        {
            var sut = new SuitComparer();
            var result = sut.Compare("Hearts", "Hearts");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareThrowsExceptionWhenFirstArgIsNotSuit()
        {
            var sut = new SuitComparer();
            Assert.ThrowsException<ArgumentException>(() => sut.Compare("Hea", "Hearts"));
        }

        [TestMethod]
        public void CompareThrowsExceptionWhenSecondArgIsNotSuit()
        {
            var sut = new SuitComparer();
            Assert.ThrowsException<ArgumentException>(() => sut.Compare("Hearts", "Hea"));
        }

        [TestMethod]
        public void CompareReturnsPositiveWhenFirstSuitIsHigher()
        {
            var sut = new SuitComparer();
            var result = sut.Compare("Diamonds", "Hearts");
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareReturnsPositiveWhenFirstSuitIsLower()
        {
            var sut = new SuitComparer();
            var result = sut.Compare("Hearts", "Diamonds");
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void SuitsAreInCorrectOrderAscending()
        {
            var sut = new SuitComparer();
            var result = sut.Compare("Hearts", "Diamonds");
            Assert.IsTrue(result < 0);
            result = sut.Compare("Hearts", "Clubs");
            Assert.IsTrue(result < 0);
            result = sut.Compare("Hearts", "Spades");
            Assert.IsTrue(result < 0);
            result = sut.Compare("Diamonds", "Clubs");
            Assert.IsTrue(result < 0);
            result = sut.Compare("Diamonds", "Spades");
            Assert.IsTrue(result < 0);
            result = sut.Compare("Clubs", "Spades");
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void SuitsAreInCorrectOrderDescending()
        {
            var sut = new SuitComparer();
            var result = sut.Compare("Spades", "Clubs");
            Assert.IsTrue(result > 0);
            result = sut.Compare("Spades", "Diamonds");
            Assert.IsTrue(result > 0);
            result = sut.Compare("Spades", "Hearts");
            Assert.IsTrue(result > 0);
            result = sut.Compare("Clubs", "Diamonds");
            Assert.IsTrue(result > 0);
            result = sut.Compare("Clubs", "Hearts");
            Assert.IsTrue(result > 0);
            result = sut.Compare("Diamonds", "Hearts");
            Assert.IsTrue(result > 0);
        }
    }
}
