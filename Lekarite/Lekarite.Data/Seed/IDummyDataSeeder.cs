namespace Lekarite.Data.Seed
{
    using Interfaces;
    using Seed.RandomSeedGenerator;

    public interface IDummyDataSeeder
    {
        void Seed(ILekariteData data, IRandomGenerator generator);
    }
}
