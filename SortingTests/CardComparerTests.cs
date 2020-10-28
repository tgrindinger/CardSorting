using CardSorting;
using DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTests
{
    [TestClass]
    public class CardComparerTests
    {
        [TestMethod]
        public void CompareReturnsZeroWhenEqual()
        {
            var card1 = new Card("Hearts", 'A');
            var card2 = new Card("Hearts", 'A');
            var sut = new CardComparer(new ValueComparer(), new SuitComparer());
            var result = sut.Compare(card1, card2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareReturnsPositiveWhenFirstValueHigher()
        {
            var card1 = new Card("Hearts", '3');
            var card2 = new Card("Hearts", '2');
            var sut = new CardComparer(new ValueComparer(), new SuitComparer());
            var result = sut.Compare(card1, card2);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareReturnsNegativeWhenFirstValueLower()
        {
            var card1 = new Card("Hearts", '2');
            var card2 = new Card("Hearts", '3');
            var sut = new CardComparer(new ValueComparer(), new SuitComparer());
            var result = sut.Compare(card1, card2);
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareReturnsPositiveWhenFirstSuitHigher()
        {
            var card1 = new Card("Diamonds", '2');
            var card2 = new Card("Hearts", '2');
            var sut = new CardComparer(new ValueComparer(), new SuitComparer());
            var result = sut.Compare(card1, card2);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareReturnsNegativeWhenFirstSuitLower()
        {
            var card1 = new Card("Hearts", '2');
            var card2 = new Card("Diamonds", '2');
            var sut = new CardComparer(new ValueComparer(), new SuitComparer());
            var result = sut.Compare(card1, card2);
            Assert.IsTrue(result < 0);
        }
    }
}
