using Interfaces;

namespace DataObjects
{
    internal class Card : ICard
    {
        public string Suit { get; private set; }
        public char Value { get; private set; }

        public Card(string suit, char rank)
        {
            Suit = suit;
            Value = rank;
        }
    }
}
