namespace Lekarite.Data.Seed
{
    using System;
    using System.Linq;

    using Lekarite.Data.Interfaces;
    using Lekarite.Models;

    public class DoctorsDataSeeder : DataSeeder, IDataSeeder
    {
        public DoctorsDataSeeder(string pathToCsvFile)
            : base(pathToCsvFile)
        {
        }

        public void Seed(ILekariteData data)
        {
            int entriesAddedAfterSave = 0;
            int cityId = 0;
            var cities = data.Cities.All().Select(c => new { Id = c.Id, Name = c.Name });

            foreach (var line in this.DataAllLines)
            {
                var splitedLine = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitedLine.Length == 1)
                {
                    var cityName = splitedLine[0];
                    cityId = cities.First(c => c.Name.Equals(cityName)).Id;
                }
                else
                {
                    string uin = splitedLine[0];
                    string firstName = splitedLine[1];
                    string secondName = splitedLine.Length == 4 ? splitedLine[2] : null;
                    string lastName = splitedLine[splitedLine.Length - 1];

                    data.Doctors.Add(new Doctor()
                    {
                        Uin = uin,
                        FirstName = firstName,
                        SecondName = secondName,
                        LastName = lastName,
                        CityId = cityId
                    });

                    entriesAddedAfterSave++;
                    if (entriesAddedAfterSave == 150)
                    {
                        data.SaveChanges();
                        entriesAddedAfterSave = 0;
                    }
                }
            }
        }
    }
}
