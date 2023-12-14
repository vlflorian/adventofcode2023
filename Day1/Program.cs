// https://adventofcode.com/2023/day/1
var lines = File.ReadAllText("input.txt").Split('\n').Where(x => !string.IsNullOrWhiteSpace(x));
var totalSum = 0;
foreach (var line in lines)
{
    var firstDigit = line.FirstOrDefault(char.IsDigit);
    var lastDigit = line.LastOrDefault(char.IsDigit);
    var combined = firstDigit.ToString() + lastDigit.ToString();
    totalSum += int.Parse(combined);
    Console.WriteLine($"{line} -> {firstDigit}, {lastDigit} -> {combined}");
}

Console.WriteLine($"Total sum is {totalSum}");  // 55971 ✔