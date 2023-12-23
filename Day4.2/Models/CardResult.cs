namespace Day4._2.Models;

/// <summary>
/// Represents a single Elf Scratchcard, containing the processed data of 1 line.
/// Example line:
/// Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
/// Where numbers before | are the winning numbers, after | are the elves' numbers.
///
/// Edit: scratch that, for efficiency I changed this to just contain the amount of winning numbers the elf has. It's all we need for day 4 part 2. 
/// </summary>
/// <param name="WinningNumbers"></param>
/// <param name="MyNumbers"></param>
public record struct CardResult(int AmountOfWinningNumbers);