namespace PlayCards.Core.Models
{
    public class Card
    {
        public Rank Rank { get; }
        public Suit Suit { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString() => $"{Rank} of {Suit}";
    }
}
