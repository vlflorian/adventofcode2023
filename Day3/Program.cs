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
"; // In this schematic, two numbers are not part numbers because they are not adjacent to a symbol: 114 (top right) and 58 (middle right). Every other number is adjacent to a symbol and so is a part number; their sum is 4361.

// var lines = sampleInput.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));
var lines = File.ReadAllText("input.txt").Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));

var (foundNumbers, foundSymbols) = InputScanner.ScanNumbersAndSymbols(lines);

var numbersAdjacentToSymbol = new List<Number>();
foreach (var (symbolLineNumber, symbol, symbolIndex) in foundSymbols)
{
    var numbersCloseToCurrentSymbol = foundNumbers.Where(number =>
            (number.LineNumber == symbolLineNumber && (symbolIndex - 1 == number.EndIndex || symbolIndex + 1 == number.StartIndex)) // numbers on same line as symbol
            || (number.LineNumber == symbolLineNumber - 1 && number.StartIndex <= symbolIndex + 1 && symbolIndex -1 <= number.EndIndex) // numbers on line above as symbol. Can be directly above or 1 to left or 1 to right
            || (number.LineNumber == symbolLineNumber + 1 && number.StartIndex <= symbolIndex + 1 && symbolIndex -1 <= number.EndIndex) // numbers on line below as symbol. Can be directly below or 1 to left or 1 to right
    ).ToList();
    numbersAdjacentToSymbol.AddRange(numbersCloseToCurrentSymbol);
}

var sum = numbersAdjacentToSymbol
    .Distinct()
    .Select(x => x.Nr)
    .Sum();
Console.WriteLine($"Sum is {sum}");