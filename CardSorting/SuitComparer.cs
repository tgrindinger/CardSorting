using System;
using System.Collections.Generic;

namespace CardSorting
{
    internal interface ISuitComparer : IComparer<string> { }

    internal class SuitComparer : ISuitComparer
    {
        private readonly IEnumerable<string> Suits = new List<string>
        {
            "Hearts",
            "Diamonds",
            "Clubs",
            "Spades",
        };
        private IDictionary<string, int> SuitOrder;

        public int Compare(string x, string y)
        {
            if (SuitOrder == null)
            {
                InitializeSuitOrder();
            }
            Validate(x);
            Validate(y);
            return SuitOrder[x] - SuitOrder[y];
        }

        private void Validate(string suit)
        {
            if (!SuitOrder.ContainsKey(suit))
            {
                throw new ArgumentException($"{suit} is not a valid suit. Must be one of {string.Join(", ", Suits)}");
            }
        }

        private void InitializeSuitOrder()
        {
            SuitOrder = new Dictionary<string, int>();
            foreach (var suit in Suits)
            {
                SuitOrder.Add(suit, SuitOrder.Count);
            }
        }
    }
}
