using PlayCards.Core;
using PlayCards.Core.Services;

class Program
{
    static void Main(string[] args)
    {
        var shuffleService = new SuffleService();
        var deck = new Deck(shuffleService);

        deck.Shuffle();
        Console.WriteLine("Shuffled deck:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(deck.Draw());
        }
    }
}