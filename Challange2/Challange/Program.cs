﻿using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {


        Dictionary<(int, int, int), string> outputs = new Dictionary<(int, int, int), string>
        {
            {(0, 0, 0), "VeniVidiVici"},
            {(0, 0, -1), "VeniVidi"},
            {(0, -1, -1), "Veni"},
            {(-1, -1, -1), ""}
        };

        for (int i = 1; i <= 100; i++)
        {
            int mod3 = i % 3;
            int mod5 = i % 5;
            int mod9 = i % 9;

            string output = outputs.Keys
                .Where(key => key.Item1 == mod3 && key.Item2 == mod5 && (key.Item3 == -1 || key.Item3 == mod9))
                .Select(key => outputs[key])
                .DefaultIfEmpty(GetDefaultOutput(mod3 + 1))
                .First();

            Console.WriteLine($"{i}:{output}");
        }
    }

    static string GetDefaultOutput(int mod3)
    {
        string[] defaultOutputs = { "", "Veni", "", "", "", "Veni", "", "", "" };
        return defaultOutputs[mod3];
    }
}
