/**************************************************************
Name: Pietro Borges Parri
Date started: 18/11/2025 (DD/MM/YY)
Code: Sample Challenge Amazon #2 (HackerRank)
**************************************************************/

using System;
using System.Text;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Resources;
using System.Diagnostics.CodeAnalysis;

public class Program
{
    public static void Main()
    {
        foreach(int i in numberOfItems("|**|*|*", [1,1], [5,6]))
        {
            Console.WriteLine(i);
        }
    }

    public static List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
    {
        List<int> result = new List<int>();
        int n = s.Length;

        int[] prefix = new int[n];     // prefix[i] = total '*' until i
        int[] left = new int[n];       // left[i]  = last '|' before or in i
        int[] right = new int[n];      // right[i] = next '|' after or in i


        // This code utilizes the same logic for the stars, left and right pipe
        // It just counts how many stars are there, and what is the position of the valid pipes
        // Then, it uses these data to count how many valid stars are inside of the pipes

        // PREFIX SUM (how many * until each position)
        int stars = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '*') stars++;
            prefix[i] = stars;
        }

        // LEFT PIPE (last '|' to the left)
        int lastPipe = -1;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '|') lastPipe = i;
            left[i] = lastPipe;
        }

        // RIGHT PIPE (next '|' to the right)
        lastPipe = -1;
        for (int i = n - 1; i >= 0; i--)
        {
            if (s[i] == '|') lastPipe = i;
            right[i] = lastPipe;
        }

        // QUERIES

        for (int q = 0; q < startIndices.Count; q++)
        {
            int l = startIndices[q] - 1;   // set index to 0-based (because they come 1-based)
            int r = endIndices[q] - 1;

            int L = right[l];  // first '|' after or in l
            int R = left[r];   // last '|' before or in r

            if (L == -1 || R == -1 || L >= R) // check if there are no valid pipes
                result.Add(0); // add nothing if the positions are invalid
            else
                result.Add(prefix[R] - prefix[L]); // count stars and add to the result
        }

        return result;
    }
}