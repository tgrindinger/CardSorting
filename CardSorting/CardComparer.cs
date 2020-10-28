using System.Collections.Generic;
using Interfaces;

namespace CardSorting
{
    internal interface ICardComparer : IComparer<ICard> { }

    internal class CardComparer : ICardComparer
    {
        private readonly IValueComparer ValueComparer;
        private readonly ISuitComparer SuitComparer;

        public CardComparer(IValueComparer valueComparer, ISuitComparer suitComparer)
        {
            ValueComparer = valueComparer;
            SuitComparer = suitComparer;
        }

        public int Compare(ICard x, ICard y)
        {
            var result = ValueComparer.Compare(x.Value, y.Value);
            if (result == 0)
            {
                result = SuitComparer.Compare(x.Suit, y.Suit);
            }
            return result;
        }
    }
}
