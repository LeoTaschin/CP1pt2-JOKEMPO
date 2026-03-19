using System.Collections.Generic;
using System.Linq;

namespace CardGame.Core
{
    public sealed class Hand
    {
        private readonly List<Card> _cards = new();

        public IReadOnlyList<Card> Cards => _cards.AsReadOnly();

        public int Count => _cards.Count;

        public void Add(Card card)
        {
            if (card is null) throw new System.ArgumentNullException(nameof(card));
            _cards.Add(card);
        }

        public void AddRange(IEnumerable<Card> cards)
        {
            if (cards is null) throw new System.ArgumentNullException(nameof(cards));
            _cards.AddRange(cards);
        }

        public bool Remove(Card card) => _cards.Remove(card);

        public void Clear() => _cards.Clear();

        public Card? HighestCard() => _cards.OrderByDescending(c => c.Rank).FirstOrDefault();

        public int TotalValue() => _cards.Sum(c => (int)c.Rank);

        public override string ToString() => string.Join(", ", _cards);
    }
}
