namespace Lekarite.Data.Seed.RandomSeedGenerator
{
    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomText(int wordsCount);
    }
}
