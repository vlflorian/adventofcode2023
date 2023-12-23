using System.Text.RegularExpressions;
using Day4._2.Models;

namespace Day4._2;

public static class InputProcessor
{
    internal static Dictionary<int, List<CardResult>> ProcessRawCardResults(IEnumerable<string> lines)
    {
        var cardDict = new Dictionary<int, List<CardResult>>();
        foreach (var line in lines)
        {
            var allNumbers = line.Split(':')[1].Replace("  ", " ");
            var winningNumbers = allNumbers.Split(" | ")[0].Trim().Split(' ').Select(int.Parse).ToList();
            var myNumbers = allNumbers.Split(" | ")[1].Trim().Split(' ').Select(int.Parse).ToList();
            
            var matchingNumbersCount = winningNumbers.Intersect(myNumbers).Count();
            cardDict.Add(GetCardId(line), [new CardResult(matchingNumbersCount)]);
        }

        return cardDict;
    }

    static int GetCardId(string s)
    {
        var regex = new Regex("Card( +)(\\d+):");
        var regexMatch = regex.Match(s);
        var gameIdStr = regexMatch.Groups[2].Value;
        return int.Parse(gameIdStr);
    }
}
