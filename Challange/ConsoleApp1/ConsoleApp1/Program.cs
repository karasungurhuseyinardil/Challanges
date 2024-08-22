using System;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\Monster\OneDrive\Masaüstü\Challange\Stok.csv";

        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("StokKodu");
        dataTable.Columns.Add("StokBarkod");
        dataTable.Columns.Add("StokAdi");
        dataTable.Columns.Add("Miktar");
        dataTable.Columns.Add("OlcuBirimi");

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var columns = line.Split(';');
                if (columns.Length == 3)
                {
                    string stokKodu = columns[0];
                    string stokBarkod = columns[1];
                    string stokAdi = columns[2];

                    string miktar = "0";
                    string olcuBirimi = "";

   
                    Match match = Regex.Match(stokAdi, @"(\d+[,\.]?\d*)\s?(GR|LT|KG|ML)", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        miktar = match.Groups[1].Value.Replace(",", ".");
                        olcuBirimi = match.Groups[2].Value.ToUpper();
                    }

                    dataTable.Rows.Add(stokKodu, stokBarkod, stokAdi, miktar, olcuBirimi);
                }
            }

            Console.WriteLine("{0,-10} {1,-15} {2,-40} {3,-10} {4,-10}", "StokKodu", "StokBarkod", "StokAdi", "Miktar", "OlcuBirimi");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine("{0,-10} {1,-15} {2,-40} {3,-10} {4,-10}",
                    row["StokKodu"],
                    row["StokBarkod"],
                    row["StokAdi"],
                    row["Miktar"],
                    row["OlcuBirimi"]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }
    }
}
