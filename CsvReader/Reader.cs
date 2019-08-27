using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvReaderList
{
    class Reader
    {
        private string csvFilePath;

        public Reader(string csvfilepath)
        {
            this.csvFilePath = csvfilepath;
        }

        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (StreamReader sr = new StreamReader(csvFilePath))
            {
                sr.ReadLine();

                for (int i = 0; i < nCountries; i++)
                {
                    string csvline = sr.ReadLine();
                    countries[i] = ReadCountryFromCsvLine(csvline);
                }
            }

            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvline)
        {
            string[] parts = csvline.Split(new char[] { ',' });

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }
    }
}
