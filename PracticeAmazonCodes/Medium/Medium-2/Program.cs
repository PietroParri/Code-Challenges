/**************************************************************
Name: Pietro Borges Parri
Date started: 15/11/2025 (DD/MM/YY)
Code: Customer Review Analyzer
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
        string[] reviews = [
            "This product is really good and useful",
            "bad quality ugly finish",
            "I like this item a lot"
        ];

        string[] customerIds = [
            "101",
            "102",
            "101"
        ];

        var result = GetActiveReviewers(reviews, customerIds, 4);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    public static List<string> GetActiveReviewers(string[] reviews, string[] customerIds, int k)
    {
        var banned = new HashSet<string> { "bad", "poor", "ugly" };
        var count = new Dictionary<string, int>();

        for (int i = 0; i < reviews.Length; i++)
        {
            string review = reviews[i];
            string customer = customerIds[i];

            var words = review.Split(' ');

            foreach (var w in words)
            {
                string clean = new string(w.Where(char.IsLetter).ToArray()).ToLower();

                if (clean.Length >= 3 && !banned.Contains(clean))
                {
                    count[customer] = count.GetValueOrDefault(customer) + 1;
                }
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