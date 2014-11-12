namespace Lekarite.Data.Seed
{
    using System.Linq;

    using Lekarite.Models;

    using Interfaces;
    using RandomSeedGenerator;

    public class RatingsDummyDataSeeder : IDummyDataSeeder
    {
        public void Seed(ILekariteData data, IRandomGenerator generator)
        {
            var doctorsId = data.Doctors
                .All()
                .OrderBy(d => d.SecondName)
                .Take(100)
                .Select(d => d.Id)
                .ToList();

            foreach (var doc in doctorsId)
            {
                var numberOfComments = generator.GetRandomNumber(1, 25);
                for (int i = 0; i < numberOfComments; i++)
                {
                    var rating = new Rating
                    {
                        DoctorId = doc,
                        Value = generator.GetRandomNumber(-5, 5)
                    };

                    data.Ratings.Add(rating);
                }
            }
        }
    }
}
