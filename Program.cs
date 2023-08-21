using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string csvFilePath = "Podaci.csv";
        string filteredCsvFilePath = "FiltriraniPodaci.csv";

        string[] lines = File.ReadAllLines(csvFilePath);

        using (var writer = new StreamWriter(filteredCsvFilePath))
        {
            writer.WriteLine(lines[0]); // Pisanje zaglavlja

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] fields = line.Split(',');

                if (fields.Length >= 11)
                {
                    DateTime date;
                    if (DateTime.TryParse(fields[9], out date) && date >= new DateTime(2022, 8, 1))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        Console.WriteLine("Filtriranje podataka završeno.");
        Console.ReadLine();
    }
}
