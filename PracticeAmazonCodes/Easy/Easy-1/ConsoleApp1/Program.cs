/**************************************************************
Name: Pietro Borges Parri
Date started: 14/11/2025 (DD/MM/YY)
Code: Amazon Routing
**************************************************************/

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(CountDeliveredPackages("PPDXDRC"));
    }

    public static int CountDeliveredPackages(string s)
    {
        int prepared = 0; // non-dispatched packages
        int dispatchedValid = 0; // dispatched and still-valid packages

        foreach (char word in s)
        {
            if (word == 'P')
            {
                prepared++;
            }
            else if (word == 'D')
            {
                if (prepared > 0)
                {
                    prepared--;
                    dispatchedValid++;
                }
            }
            else if (word == 'R')
            {
                if (dispatchedValid > 0)
                    dispatchedValid--;
            }
            else if (word == 'C')
            {
                if (prepared > 0)
                    prepared--;
            }
        }

        return dispatchedValid;
    }
}
