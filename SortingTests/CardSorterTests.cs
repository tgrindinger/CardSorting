using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardSorting;
using DataObjects;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTests
{
    [TestClass]
    public class CardSorterTests
    {
        // CollectionAssert.AreEqual requires the non-generic version of IComparer
        private class TestCardComparer : CardComparer, IComparer
        {
            public TestCardComparer(IValueComparer valueComparer, ISuitComparer suitComparer)
                : base(valueComparer, suitComparer)
            {
            }
            int IComparer.Compare(object x, object y)
            {
                return Compare(x as ICard, y as ICard);
            }
        }

        [TestMethod]
        public void SortReturnsSortedListWhenGivenUnsortedList()
        {
            var unsortedList = new List<ICard>
            {
                new Card("Hearts", 'A'),
                new Card("Spades", 'A'),
                new Card("Hearts", '7'),
                new Card("Clubs", '3'),
            };
            var presortedList = new List<ICard>
            {
                new Card("Clubs", '3'),
                new Card("Hearts", '7'),
                new Card("Hearts", 'A'),
                new Card("Spades", 'A'),
            };
            var comparer = new TestCardComparer(new ValueComparer(), new SuitComparer());
            var sut = new CardSorter(comparer);
            var sortedList = sut.Sort(unsortedList);
            CollectionAssert.AreEqual(presortedList, sortedList.ToList(), comparer);
        }

        [TestMethod]
        public void SortReturnsSortedListWhenGivenUnsortedListWithSameSuit()
        {
            var unsortedList = new List<ICard>
            {
                new Card("Hearts", 'A'),
                new Card("Hearts", '5'),
                new Card("Hearts", '7'),
                new Card("Hearts", '3'),
            };
            var presortedList = new List<ICard>
            {
                new Card("Hearts", '3'),
                new Card("Hearts", '5'),
                new Card("Hearts", '7'),
                new Card("Hearts", 'A'),
            };
            var comparer = new TestCardComparer(new ValueComparer(), new SuitComparer());
            var sut = new CardSorter(comparer);
            var sortedList = sut.Sort(unsortedList);
            CollectionAssert.AreEqual(presortedList, sortedList.ToList(), comparer);
        }

        [TestMethod]
        public void SortReturnsSortedListWhenGivenUnsortedListWithSameValue()
        {
            var unsortedList = new List<ICard>
            {
                new Card("Clubs", '5'),
                new Card("Hearts", '5'),
                new Card("Spades", '5'),
                new Card("Diamonds", '5'),
            };
            var presortedList = new List<ICard>
            {
                new Card("Hearts", '5'),
                new Card("Diamonds", '5'),
                new Card("Clubs", '5'),
                new Card("Spades", '5'),
            };
            var comparer = new TestCardComparer(new ValueComparer(), new SuitComparer());
            var sut = new CardSorter(comparer);
            var sortedList = sut.Sort(unsortedList);
            CollectionAssert.AreEqual(presortedList, sortedList.ToList(), comparer);
        }

        [TestMethod]
        public void SortReturnsSortedListWhenGivenUnsortedListWithMoreData()
        {
            var unsortedList = new List<ICard>
            {
                new Card("Hearts", 'A'),
                new Card("Hearts", '7'),
                new Card("Diamonds", '9'),
                new Card("Diamonds", '2'),
                new Card("Spades", '5'),
                new Card("Spades", 'A'),
                new Card("Clubs", '5'),
                new Card("Clubs", '3'),
            };
            var presortedList = new List<ICard>
            {
                new Card("Diamonds", '2'),
                new Card("Clubs", '3'),
                new Card("Clubs", '5'),
                new Card("Spades", '5'),
                new Card("Hearts", '7'),
                new Card("Diamonds", '9'),
                new Card("Hearts", 'A'),
                new Card("Spades", 'A'),
            };
            var comparer = new TestCardComparer(new ValueComparer(), new SuitComparer());
            var sut = new CardSorter(comparer);
            var sortedList = sut.Sort(unsortedList);
            CollectionAssert.AreEqual(presortedList, sortedList.ToList(), comparer);
        }
    }
}
