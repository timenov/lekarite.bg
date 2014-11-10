namespace Lekarite.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Lekarite.Data.Interfaces;
    using Lekarite.Data.Seed;

    internal sealed class Configuration : DbMigrationsConfiguration<LekariteDbContext>
    {
        private const string Seed_Files_Path = @"D:\temp\CSharp Projects\Lekarite\Lekarite\Lekarite.Data\SeedFiles\";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LekariteDbContext context)
        {
            if (context.Cities.FirstOrDefault() == null)
            {
                ILekariteData data = new LekariteData(context);
                var dataSeederExcecutors = new List<DataSeederExcecutor>
                {
                    new DataSeederExcecutor(new CitiesDataSeeder(Seed_Files_Path + "shortCities.csv")),
                    new DataSeederExcecutor(new DoctorsDataSeeder(Seed_Files_Path + "shortDoctors.csv")),
                    new DataSeederExcecutor(new SpecialitiesDataSeeder(Seed_Files_Path + "specialities.csv"))
                };

                foreach (var excecutor in dataSeederExcecutors)
                {
                    excecutor.Excecute(data);
                    data.SaveChanges();
                }
            }
        }
    }
}
