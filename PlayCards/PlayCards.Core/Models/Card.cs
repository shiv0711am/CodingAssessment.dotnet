namespace PlayCards.Core.Models
{
    public class Card
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public override string ToString() => $"{Rank} of {Suit}";
    }
}
