using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Core
{
    public abstract class GameEngine
    {
        public Deck Deck { get; }
        public List<Player> Players { get; } = new();
        public List<Round> Rounds { get; } = new();
        public int CurrentRound { get; private set; }

        protected GameEngine(Deck? deck = null)
        {
            Deck = deck ?? new Deck();
            Deck.Shuffle();
            CurrentRound = 0;
        }

        public void AddPlayer(Player player)
        {
            if (player is null) throw new ArgumentNullException(nameof(player));
            Players.Add(player);
        }

        protected void StartRound()
        {
            CurrentRound++;
            Rounds.Add(new Round(CurrentRound));
        }

        protected void EndRound() { }

        public void Deal(int cardsPerPlayer)
        {
            if (cardsPerPlayer <= 0) throw new ArgumentOutOfRangeException(nameof(cardsPerPlayer));
            if (Players.Count == 0) throw new InvalidOperationException("Não há jogadores.");

            foreach (var player in Players)
                player.ClearHand();

            for (int i = 0; i < cardsPerPlayer; i++)
            {
                foreach (var player in Players)
                {
                    if (Deck.Count == 0) throw new InvalidOperationException("Baralho vazio.");
                    player.Receive(Deck.Draw());
                }
            }
        }

        public abstract Player? EvaluateWinner();

        public virtual void PlayRound(int cardsPerPlayer)
        {
            StartRound();
            Deal(cardsPerPlayer);
            var winner = EvaluateWinner();
            if (winner != null)
                winner.Score++;
            EndRound();
        }
    }

    public sealed class HighestCardGame : GameEngine
    {
        public HighestCardGame(Deck? deck = null) : base(deck) { }

        public override Player? EvaluateWinner()
        {
            var best = Players
                .Select(p => new { Player = p, Top = p.Hand.HighestCard() })
                .Where(x => x.Top != null)
                .OrderByDescending(x => x.Top!.Rank)
                .ThenByDescending(x => x.Top!.Suit)
                .FirstOrDefault();

            return best?.Player;
        }
    }
}
