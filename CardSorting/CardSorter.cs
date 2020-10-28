using System.Collections.Generic;
using Interfaces;
using System.Linq;

namespace CardSorting
{
    public interface ICardSorter
    {
        IEnumerable<ICard> Sort(IEnumerable<ICard> cards, bool ascending = true);
    }

    internal class CardSorter : ICardSorter
    {
        private readonly ICardComparer CardComparer;

        public CardSorter(ICardComparer cardComparer)
        {
            CardComparer = cardComparer;
        }

        public IEnumerable<ICard> Sort(IEnumerable<ICard> cards, bool ascending = true)
        {
            var sorted = cards.OrderBy(c => c, CardComparer);
            return ascending ? sorted : sorted.Reverse();
        }
    }
}
