using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Core
{
    public sealed class Deck
    {
        private readonly List<Card> _cards;
        private readonly Random _random;

        public Deck(bool useStandardDeck = true, Random? random = null)
        {
            _random = random ?? new Random();
            _cards = new List<Card>();

            if (useStandardDeck)
                _cards.AddRange(Card.GetStandardDeck());
        }

        public int Count => _cards.Count;

        public void Shuffle()
        {
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                var temp = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = temp;
            }
        }

        public Card Draw()
        {
            if (!_cards.Any())
                throw new InvalidOperationException("O baralho está vazio.");

            var top = _cards[0];
            _cards.RemoveAt(0);
            return top;
        }

        public IEnumerable<Card> Draw(int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (_cards.Count < count) throw new InvalidOperationException("Não há cartas suficientes para sacar.");

            for (int i = 0; i < count; i++)
                yield return Draw();
        }

        public void Reset(bool useStandardDeck = true)
        {
            _cards.Clear();
            if (useStandardDeck)
                _cards.AddRange(Card.GetStandardDeck());
        }
    }
}
