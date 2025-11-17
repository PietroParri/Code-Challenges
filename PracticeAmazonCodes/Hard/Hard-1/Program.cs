/**************************************************************
Name: Pietro Borges Parri
Date started: 17/11/2025 (DD/MM/YY)
Code: Customer Top K Frequently Purchased Products
**************************************************************/

using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        var result = TopKFrequentProducts(["apple", "banana", "apple", "orange", "banana", "apple"], 2);
        foreach (var product in result)
        {
            Console.WriteLine(product);
        }
    }

    public static List<string> TopKFrequentProducts(string[] products, int k)
    {
        var count = new Dictionary<string, int>();
        
        foreach (var product in products)
        {
            count[product] = count.GetValueOrDefault(product, 0) + 1;
        }

        var result = count
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .Take(k)
            .Select(x => x.Key)
            .ToList();

        return result;
    }
}