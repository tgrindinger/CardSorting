using System;
using System.Collections.Generic;

namespace CardSorting
{
    internal interface IValueComparer : IComparer<char> { }

    internal class ValueComparer : IValueComparer
    {
        private readonly IEnumerable<char> Values = new List<char>
        {
            '2', '3', '4', '5', '6', '7', '8', '9', 'J', 'Q', 'K', 'A'
        };
        private IDictionary<char, int> ValueOrder;

        public int Compare(char x, char y)
        {
            if (ValueOrder == null)
            {
                InitializeValueOrder();
            }
            Validate(x);
            Validate(y);
            return ValueOrder[x] - ValueOrder[y];
        }

        private void Validate(char c)
        {
            if (!ValueOrder.ContainsKey(c))
            {
                throw new ArgumentException($"{c} is not a valid suit. Must be one of {string.Join(", ", Values)}");
            }
        }

        private void InitializeValueOrder()
        {
            ValueOrder = new Dictionary<char, int>();
            foreach (var value in Values)
            {
                ValueOrder.Add(value, ValueOrder.Count);
            }
        }
    }
}
