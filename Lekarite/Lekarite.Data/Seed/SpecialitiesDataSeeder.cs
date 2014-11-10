namespace Lekarite.Data.Seed
{
    using System;

    using Lekarite.Data.Interfaces;
    using Lekarite.Models;

    public class SpecialitiesDataSeeder : DataSeeder, IDataSeeder
    {
        public SpecialitiesDataSeeder(string pathToCsvFile)
            : base(pathToCsvFile)
        {
        }

        public void Seed(ILekariteData data)
        {
            foreach (var line in this.DataAllLines)
            {
                var splitedLine = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                int code = int.Parse(splitedLine[0]);
                string name = splitedLine[1];

                data.Specialities.Add(new Speciality()
                {
                    Code = code,
                    Name = name
                });
            }
        }
    }
}
