namespace Lekarite.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Interfaces;
    using Seed;
    using Seed.RandomSeedGenerator;

    internal sealed class Configuration : DbMigrationsConfiguration<LekariteDbContext>
    {
        private const string SeedFilesPath = @"D:\temp\CSharp Projects\Lekarite\Lekarite\Lekarite.Data\SeedFiles\";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LekariteDbContext context)
        {
            if (context.Cities.FirstOrDefault() != null)
            {
                return;
            }

            ILekariteData data = new LekariteData(context);

            var dataSeederExecutors = new List<DataSeederExcecutor>
                {
                    new DataSeederExcecutor(new CitiesDataSeeder(SeedFilesPath + "shortCities.csv")),
                    new DataSeederExcecutor(new SpecialitiesDataSeeder(SeedFilesPath + "specialities.csv")),
                    new DataSeederExcecutor(new DoctorsDataSeeder(SeedFilesPath + "shortDoctors.csv"))
                };

            foreach (var executor in dataSeederExecutors)
            {
                executor.Excecute(data);
                data.SaveChanges();
            }

            var dummyDataSeederExcecutors = new List<DummyDataSeederExcecutor>
                {
                    new DummyDataSeederExcecutor(new RatingsDummyDataSeeder()),
                    new DummyDataSeederExcecutor(new CommentsDummyDataSeeder())
                };

            foreach (var executor in dummyDataSeederExcecutors)
            {
                executor.Excecute(data, RandomGenerator.Instance);
                data.SaveChanges();
            }
        }
    }
}
