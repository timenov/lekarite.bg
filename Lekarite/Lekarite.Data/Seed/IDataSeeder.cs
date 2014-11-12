namespace Lekarite.Data.Seed
{
    using System.Collections.Generic;

    using Lekarite.Data.Interfaces;
    using Lekarite.Data.Seed.RandomSeedGenerator;

    public interface IDataSeeder
    {
        void Seed(ILekariteData data);
    }
}
