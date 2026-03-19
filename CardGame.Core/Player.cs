namespace CardGame.Core
{
    public sealed class Player
    {
        public string Name { get; init; }
        public Hand Hand { get; }

        public int Score { get; set; }

        public Player(string name)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(name));
            Hand = new Hand();
            Score = 0;
        }

        public void Receive(Card card)
        {
            if (card is null) throw new System.ArgumentNullException(nameof(card));
            Hand.Add(card);
        }

        public void ClearHand() => Hand.Clear();
    }
}
