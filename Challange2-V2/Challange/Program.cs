using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        {
            for (int i = 1; i <= 100; i++)
            {
                string output = GetOutput(i);
                Console.WriteLine($"{i}:{output}");

            }
        }
        static string GetOutput(int num)
        {
            string[] uc = ["", "Veni"];
            string[] ucbes = ["", "Vidi"];
            string[] ucbesdokuz = ["", "Vici"];
            string result = "";
            int sonuc = Convert.ToInt16((num % 3 == 0));
            result += uc[sonuc];
            sonuc = Convert.ToInt16((num % 3 == 0 && num % 5 == 0));
            result += ucbes[sonuc];
            sonuc = Convert.ToInt16((num % 3 == 0 && num % 5 == 0 && num % 9 == 0));
            result += ucbesdokuz[sonuc];
            return result;
        }
    }
}
