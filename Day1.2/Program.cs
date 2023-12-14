// https://adventofcode.com/2023/day/1
var numberMapping = new Dictionary<string, string>{
    { "one", "1" },
    { "two", "2" },
    { "three", "3" },
    { "four", "4" },
    { "five", "5" },
    { "six", "6" },
    { "seven", "7" },
    { "eight", "8" },
    { "nine", "9" },
    { "zero", "0" }
};

var lines = File.ReadAllText("input.txt").Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));
var totalSum = 0;
foreach (var line in lines)
{
    var foundNumbers = new List<(int Index,  string Number)>();
    
    // get indexes of numbers as text
    GetIndexesOfWrittenNumbers(line, foundNumbers);

    // get indexes of numbers as digits
    for (var index = 0; index < line.Length; index++)
    {
        var character = line[index];
        if (char.IsDigit(character))
        {
            foundNumbers.Add((index, character.ToString()));
        }
    }
    
    var allNumbers = foundNumbers
        .OrderBy(x => x.Index)
        .Select(x => x.Number)
        .ToList();
    
    var combined = allNumbers.First() + allNumbers.Last();
    totalSum += int.Parse(combined);
    Console.WriteLine($"{line} -> {string.Join(',', allNumbers)} -> {allNumbers.First()}, {allNumbers.Last()} -> {combined}");
}

Console.WriteLine($"Total sum is {totalSum}");
return;
// 54719 That's the right answer! You are one gold star closer to restoring snow operations.


void GetIndexesOfWrittenNumbers(string line, List<(int Index, string Number)> valueTuples)
{
    foreach (var (numberAsText, digit) in numberMapping) 
    {
        var index = -1;

        do
        {
            index = line.IndexOf(numberAsText, index + 1);
            if (index != -1)
                valueTuples.Add((index, Value: digit));
        } while (index != -1);
    }
}

