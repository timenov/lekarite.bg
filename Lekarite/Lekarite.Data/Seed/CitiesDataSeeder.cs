namespace Lekarite.Data.Seed
{
    using System;

    using Lekarite.Data.Interfaces;
    using Lekarite.Models;

    public class CitiesDataSeeder : DataSeeder, IDataSeeder
    {
        public CitiesDataSeeder(string pathToCsvFile)
            : base(pathToCsvFile)
        {
        }

        public void Seed(ILekariteData data)
        {
            foreach (var line in this.DataAllLines)
            {
                var splitedLine = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string name = splitedLine[0];
                int postalCode = int.Parse(splitedLine[1]);

                data.Cities.Add(new City
                {
                    Name = name,
                    PostalCode = postalCode
                });
            }
        }
    }
}
