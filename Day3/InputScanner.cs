using System.Text.RegularExpressions;

namespace Day3;

public static class InputScanner
{
    const string notAlphaNumOrDotRegex = "[^\\w.]";
    const string numberRegex = "\\d+";

    public static (List<Number>, List<Symbol>) ScanNumbersAndSymbols(IEnumerable<string> lines)
    {
        var foundNumbers = new List<Number>();
        var foundSymbols = new List<Symbol>();

        for (var i = 0; i < lines.Count(); i++)
        {
            var line = lines.ElementAt(i);

            // Use Regex to get all numbers in the current line + capture their StartIndex and EndIndex
            var numberMatches = new Regex(numberRegex).Matches(line);
            var numbersInLine = numberMatches.Select(x => new Number(i, int.Parse(x.Value), x.Index, x.Index + x.Value.Length - 1));
            foundNumbers.AddRange(numbersInLine);

            // Use Regex to get all symbols in the current line + capture their Index
            var symbolMatches = new Regex(notAlphaNumOrDotRegex).Matches(line);
            var symbolsInLine = symbolMatches.Select(x => new Symbol(i, x.Value, x.Index));
            foundSymbols.AddRange(symbolsInLine);
        }

        return (foundNumbers, foundSymbols);
    }
}