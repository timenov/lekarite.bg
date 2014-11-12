namespace Lekarite.Data.Seed
{
    using Interfaces;
    using Seed.RandomSeedGenerator;

    public class DummyDataSeederExcecutor
    {
        private readonly IDummyDataSeeder seeder;

        public DummyDataSeederExcecutor(IDummyDataSeeder dataSeeder)
        {
            this.seeder = dataSeeder;
        }

        public IDummyDataSeeder DataSeeder
        {
            get { return this.seeder; }
        }

        public void Excecute(ILekariteData data, IRandomGenerator generator)
        {
            this.DataSeeder.Seed(data, generator);
        }
    }
}
