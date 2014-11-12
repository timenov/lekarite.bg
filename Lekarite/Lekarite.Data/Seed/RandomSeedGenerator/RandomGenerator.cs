namespace Lekarite.Data.Seed.RandomSeedGenerator
{
    using System;

    public class RandomGenerator : IRandomGenerator
    {
        private static RandomGenerator instance;

        private const string Letters = "АаБбВвГгДдЕеЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъьЮюЯя";

        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance 
        {
            get
            {
                return instance ?? (instance = new RandomGenerator());
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(chars);
        }

        public string GetRandomText(int wordsCount)
        {
            string[] words = new string[wordsCount];

            for (int i = 0; i < wordsCount; i++)
            {
                words[i] = this.GetRandomString(this.GetRandomNumber(2, 10));
            }

            return string.Join(" ", words);
        }
    }
}
