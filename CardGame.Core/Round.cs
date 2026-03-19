using System.Collections.Generic;

namespace CardGame.Core
{
    public sealed class Round
    {
        public int Number { get; init; }
        public Dictionary<Player, List<Card>> Plays { get; } = new();

        public Round(int number)
        {
            if (number < 1) throw new System.ArgumentOutOfRangeException(nameof(number));
            Number = number;
        }

        public void AddPlay(Player player, Card card)
        {
            if (!Plays.ContainsKey(player))
                Plays[player] = new List<Card>();
            Plays[player].Add(card);
        }
    }
}
