using System;
using System.Collections.Generic;

namespace CsvReaderList
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Repos\CsvReaderList\CountryPopulations.csv";

            Reader csvreader = new Reader(filepath);

            List<Country> countries = csvreader.ReadAllCountries();
            Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            int lilliputindex = countries.FindIndex(x=>x.Population < 2_000_000);
            countries.Insert(lilliputindex,lilliput);
            countries.RemoveAt(lilliputindex);

            foreach(Country country in countries)
            {
                Console.WriteLine($"{Formatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            Console.WriteLine($"{countries.Count} countries");
        }
    }
}
