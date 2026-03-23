/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;
using System.IO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "basketball.csv"));
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);
            if (!players.ContainsKey(playerId)) {
                players[playerId] = 0;
            }
            players[playerId] += points;
        }

        Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        // Convert dictionary to array and sort by points descending
        var playerList = players.ToArray();
        Array.Sort(playerList, (a, b) => b.Value.CompareTo(a.Value));

        // Display top 10 in a table
        Console.WriteLine("\nTop 10 Players by Total Points:");
        Console.WriteLine("Rank | Player ID    | Total Points");
        Console.WriteLine("-----|--------------|-------------");
        for (int i = 0; i < Math.Min(10, playerList.Length); i++) {
            Console.WriteLine($"{i + 1,4} | {playerList[i].Key,-12} | {playerList[i].Value,12}");
        }

        var topPlayers = new string[10];
    }
}