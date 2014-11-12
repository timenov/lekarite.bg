namespace Lekarite.Data.Seed
{
    using System;
    using System.Linq;

    using Lekarite.Models;

    using Interfaces;
    using RandomSeedGenerator;

    public class CommentsDummyDataSeeder : IDummyDataSeeder
    {
        public void Seed(ILekariteData data, IRandomGenerator generator)
        {
            var doctorsId = data.Doctors
                .All()
                .OrderBy(d => d.LastName)
                .Take(100)
                .Select(d => d.Id)
                .ToList();
            var index = 0;

            foreach (var doc in doctorsId)
            {
                var numberOfComments = generator.GetRandomNumber(1, 10);

                for (int i = 0; i < numberOfComments; i++)
                {
                    var content = generator.GetRandomText(generator.GetRandomNumber(3, 20));
                    DateTime created = DateTime.Now.AddHours(generator.GetRandomNumber(-268, 0));

                    var comment = new Comment
                    {
                        Content = content,
                        CreatedOn = created,
                        DoctorId = doc
                    };

                    data.Comments.Add(comment);
                    index++;
                }

                if (index % 20 == 0)
                {
                    data.SaveChanges();
                }
            }
        }
    }
}
