/**************************************************************
Name: Pietro Borges Parri
Date started: 14/11/2025 (DD/MM/YY)
Code: Request Frequency Counter
**************************************************************/

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> map = CountRequests(new string[] {"create", "get", "get", "update", "get"});
        foreach (var i in map)
        {
            Console.WriteLine($"{i.Key} = {i.Value}");
        }
    }

    public static Dictionary<string, int> CountRequests(string[] requests)
    {
        var count = new Dictionary<string, int>();

        foreach (string req in requests)
            count[req] = count.GetValueOrDefault(req, 0) + 1;

        return count;
    }
}