/**************************************************************
Name: Pietro Borges Parri
Date started: 17/11/2025 (DD/MM/YY)
Code: Customer Longest Valid Package Sequence
**************************************************************/

using System;
using System.Text;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        string s = "PPDPCRDPDDRPPCDRPPDRPCRPDPCCPRDPDPCRRPDDPCPDRRPPCDRPPPCDRPPRRDPDPCRPPDRP";
        System.Console.WriteLine("Size = " + LongestValidPackageSequence(s));
    }

    public static int LongestValidPackageSequence(string s)
    {
        int prepared = 0;
        int dispatched = 0;
        int maxSize = 0;
        var substring = new StringBuilder();

        s = s.ToUpper();

        for (int i = 0; i < s.Length; i++)
        {
            char a = s[i];

            switch (a)
            {
                case 'P':
                    prepared++;
                    substring.Append(a);
                    break;
                case 'D':
                    if (prepared <= 0)
                    {
                        Reset();
                        continue;
                    }

                    prepared--;
                    dispatched++;
                    substring.Append(a);
                    break;
                case 'C':
                    if (prepared <= 0)
                    {
                        Reset();
                        continue;
                    }
                    prepared--;
                    substring.Append(a);
                    break;
                case 'R':
                    if (dispatched <= 0)
                    {
                        Reset();
                        continue;
                    }
                    dispatched--;
                    substring.Append(a);
                    break;
            }
        }

        void Reset()
        {
            maxSize = Math.Max(maxSize, substring.Length);
            prepared = 0;
            dispatched = 0;
            substring.Clear();
        }
        
        maxSize = Math.Max(maxSize, substring.Length);
        return maxSize;
    }
}