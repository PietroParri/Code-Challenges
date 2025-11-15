/**************************************************************
Name: Pietro Borges Parri
Date started: 14/11/2025 (DD/MM/YY)
Code: Transaction Log Analyzer
**************************************************************/

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> result = GetUsersWithKTransactions(new string[] {
        "88 99 200",    // 88->99
        "99 88 300",    // 99->88
        "88 88 100",    // deposit
        "77 88 50"      // 77->88
        }, 2);

        foreach (string item in result)
        {
            System.Console.WriteLine(item);
        }
    }
    public static List<string> GetUsersWithKTransactions(string[] logs, int k)
    {
        var count = new Dictionary<string, int>();

        foreach (var log in logs)
        {
            var parts = log.Split(' ');
            string sender = parts[0];
            string receiver = parts[1];

            if (sender == receiver)
            {
                count[sender] = count.GetValueOrDefault(sender, 0) + 1;
            }
            else
            {
                count[sender] = count.GetValueOrDefault(sender, 0) + 1;
                count[receiver] = count.GetValueOrDefault(receiver, 0) + 1;
            }
        }

        var result = count
            .Where(x => x.Value >= k)
            .Select(x => x.Key)
            .OrderBy(x => x)
            .ToList();

        return result;
    }
}