// https://adventofcode.com/2023/day/3

using Day3;

var sampleInput = @"
467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..
"; // A gear is any * symbol that is adjacent to exactly two part numbers. Its gear ratio is the result of multiplying those two numbers together.
   // This time, you need to find the gear ratio of every gear and add them all up so that the engineer can figure out which gear needs to be replaced..

// var lines = sampleInput.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));
var lines = File.ReadAllText("input.txt").Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));

var (foundNumbers, foundSymbols) = InputScanner.ScanNumbersAndSymbols(lines);

var sum = 0;
foreach (var (symbolLineNumber, symbol, symbolIndex) in foundSymbols)
{
     var numbersNextToGear = foundNumbers.Where(number =>
             (number.LineNumber == symbolLineNumber && (symbolIndex - 1 == number.EndIndex || symbolIndex + 1 == number.StartIndex)) // numbers on same line as symbol
             || (number.LineNumber == symbolLineNumber - 1 && number.StartIndex <= symbolIndex + 1 && symbolIndex -1 <= number.EndIndex) // numbers on line above as symbol. Can be directly above or 1 to left or 1 to right
             || (number.LineNumber == symbolLineNumber + 1 && number.StartIndex <= symbolIndex + 1 && symbolIndex -1 <= number.EndIndex) // numbers on line below as symbol. Can be directly below or 1 to left or 1 to right
     ).ToList();
     if (numbersNextToGear.Count == 2)
        sum += numbersNextToGear[0].Nr * numbersNextToGear[1].Nr;
}

Console.WriteLine($"Sum is {sum}");