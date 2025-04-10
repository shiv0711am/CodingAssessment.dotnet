using PlayCards.Core.Models;
using PlayCards.Core.Services;

namespace PlayCards.Core
{
    public class Deck
    {
        private readonly IShuffleService _shuffleService;
        private IList<Card> _deck;
        public Deck(IShuffleService shuffleService)
        {
            _shuffleService = shuffleService;
            _deck = GenerateDeck();
        }

        private IList<Card> GenerateDeck()
        {
            var deck = new List<Card>();
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }

        public void Shuffle() => _deck = _shuffleService.Shuffle(_deck);

        public Card Draw()
        {
            if(_deck.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty");
            }
            var top = _deck[0];
            _deck.RemoveAt(0);
            return top;
        }

        public int Count => _deck.Count;
    }
}
