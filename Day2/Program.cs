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

// The Elf would first like to know which games would have been possible if the bag contained only 12 red cubes, 13 green cubes, and 14 blue cubes
var availableCubesInBag = new Dictionary<string, int>
{
    { "red", 12 },
    { "green", 13 },
    { "blue", 14 },
};

var gameIdSum = 0;
foreach (var line in lines)
{
    var gameId = GetGameId(line);
    var matches = new Regex("(\\d+) (blue|green|red)").Matches(line);
    var rawCubePulls = matches.Select(x => x.Value); // e.g. ["4 red", "2 green", ...]
    var cubePulls = rawCubePulls
        .Select(x => x.Split(' ')) // separate number and colour
        .Select(x => (Colour: x[1], AmountOfCubes: int.Parse(x[0]))); // convert to tuple
    
    // game is impossible if any of the cube pulls exceed the number of available cubes
    var gameIsImpossible = cubePulls.Any(cubePull => cubePull.AmountOfCubes > availableCubesInBag[cubePull.Colour]);
    var gameIsPossible = !gameIsImpossible;
    Console.WriteLine($"Game {gameId} is possible is {gameIsPossible}");
    if (gameIsPossible == true)
        gameIdSum += gameId;
}

Console.WriteLine($"Sum of gameIds: {gameIdSum}");

int GetGameId(string s)
{
    var regex = new Regex("Game (\\d+):");
    var regexMatch = regex.Match(s);
    var gameIdStr = regexMatch.Groups[1].Value;
    return int.Parse(gameIdStr);
}