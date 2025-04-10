using PlayCards.Core.Models;

namespace PlayCards.Core.Services
{
    public class SuffleService : IShuffleService
    {
        public IList<Card> Shuffle(IList<Card> deck)
        {
            var random = new Random();
            return deck.OrderBy(_ => random.Next()).ToList();        
        }
    }
}
