namespace Lekarite.Data.Seed
{
    using System.Collections.Generic;

    using Lekarite.Data.Interfaces;

    public interface IDataSeeder
    {
        void Seed(ILekariteData data);
    }
}
