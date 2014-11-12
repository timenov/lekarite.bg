namespace Lekarite.Data.Seed
{
    using Interfaces;

    public class DataSeederExcecutor
    {
        private readonly IDataSeeder seeder;

        public DataSeederExcecutor(IDataSeeder dataSeeder)
        {
            this.seeder = dataSeeder;
        }

        public IDataSeeder DataSeeder
        {
            get { return this.seeder; }
        }

        public void Excecute(ILekariteData data)
        {
            this.DataSeeder.Seed(data);
        }
    }
}
