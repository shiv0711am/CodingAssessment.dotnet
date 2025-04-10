# Development environment setup
	- Create the projects -> Console(PlayCards.Console), Library(PlayCards.Core) and tests(PlayCards.Core.Tests)
	- Setup the git
# Scaffold/structure of your solution
	PlayCards
		|
		|--PlayCards.Console/
		|		|
		|		|--Program.cs
		|
		|--PlayCards.Core/
		|		|
		|		|--Models
		|		|	|
		|		|	|--Rank.cs
		|		|	|--Suit.cs
		|		|	|--Card.cs
		|		|
		|		|--Services
		|		|	|
		|		|	|--IShuffleService.cs
		|		|	|--SuffleService.cs
		|		|
		|		|--Deck.cs
		|
		|--PlayCards.Core.Tests
				|
				|--DeckTests.cs
