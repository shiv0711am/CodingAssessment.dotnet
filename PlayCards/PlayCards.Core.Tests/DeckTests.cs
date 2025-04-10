using Moq;
using PlayCards.Core.Services;

namespace PlayCards.Core.Tests
{
    public class DeckTests
    {
        private Deck _sut;
        private Mock<IShuffleService> _suffleService;

        public DeckTests()
        {
            _suffleService = new Mock<IShuffleService>();
            _sut = new Deck(_suffleService.Object);
        }

        [Fact]
        public void Deck_Has52Cards()
        {
            Assert.Equal(52, _sut.Count);
        }

        [Fact]
        public void Deck_CardIsDrawn()
        {
            _sut.Draw();
            Assert.Equal(51, _sut.Count);
        }
    }
}