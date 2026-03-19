namespace CardGame.Core
{
    public enum Suit
    {
        Copas,
        Ouros,
        Espadas,
        Paus
    }

    public enum Rank
    {
        Dois = 2,
        Tres = 3,
        Quatro = 4,
        Cinco = 5,
        Seis = 6,
        Sete = 7,
        Oito = 8,
        Nove = 9,
        Dez = 10,
        Valete = 11,
        Dama = 12,
        Rei = 13,
        As = 14
    }

    public sealed class Card
    {
        public Suit Suit { get; init; }
        public Rank Rank { get; init; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString() => $"{Rank} de {Suit}";

        public static IEnumerable<Card> GetStandardDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    yield return new Card(suit, rank);
                }
            }
        }
    }
}
