using PlayCards.Core.Models;

namespace PlayCards.Core.Services
{
    public interface IShuffleService
    {
        IList<Card> Shuffle(IList<Card> deck);
    }
}
