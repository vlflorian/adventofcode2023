using Day4._2;

var sampleInput = @"
Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
"; // winning numbers before |, lottery numbers after 

// var lines = sampleInput.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));
var lines = File.ReadAllText("input.txt").Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));

var cardDict = InputProcessor.ProcessRawCardResults(lines);

// because we're going to duplicate lines, each cardId now has a list of matching cards
foreach (var (cardId, cardsForId) in cardDict)
{
    foreach (var card in cardsForId)
    {
        Console.WriteLine($"Card {cardId} has {card.AmountOfWinningNumbers} winning numbers. Adding {card.AmountOfWinningNumbers} new games! ");
        
        for (var i = cardId + 1; i <= cardId + card.AmountOfWinningNumbers; i++)
        {
            Console.WriteLine($"Card {cardId}: Duplicating card {i}...");
            
            // get any card for card number i (first one since they're all duplicates)
            var cardResult = cardDict[i][0];
            
            // duplicate the card
            cardDict[i].Add(cardResult);
        } 
    }
}

var totalAmountOfScratchCardsAfterDuplication = cardDict.Sum(x => x.Value.Count);
Console.WriteLine($"Total amount of scratchcards: {totalAmountOfScratchCardsAfterDuplication}.");

