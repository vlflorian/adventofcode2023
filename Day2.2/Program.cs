using System.Text.RegularExpressions;
// https://adventofcode.com/2023/day/2

var sampleInput = @"
Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
";
// var lines = sampleInput.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));
var lines = File.ReadAllText("input.txt").Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));

var totalPower = 0; // 💪 🔋 🏋️‍♀️
foreach (var line in lines)
{
    var matches = new Regex("(\\d+) (blue|green|red)").Matches(line);
    var rawCubePulls = matches.Select(x => x.Value); // e.g. ["4 red", "2 green", ...]
    var cubePulls = rawCubePulls
        .Select(x => x.Split(' ')) // separate number and colour
        .Select(x => (Colour: x[1], AmountOfCubes: int.Parse(x[0]))); // convert to tuple

    var maxAmountOfColour = cubePulls
        .GroupBy(x => x.Colour)
        .Select(x => (Colour: x.Key, Max: x.Max(y => y.AmountOfCubes)))
        .ToList();
    
    var power = maxAmountOfColour.Aggregate(1, (current, next) => current * next.Max);
    Console.WriteLine($"{string.Join(',', maxAmountOfColour)}, power of {power}");
    totalPower += power;
}

Console.WriteLine($"TOTAL POWER: {totalPower}");
