namespace Lekarite.Data.Interfaces
{
    using System;

    using Lekarite.Models;

    public interface ILekariteData
    {
        IRepository<User> Users { get; }

        IRepository<Doctor> Doctors { get; }

        IRepository<Speciality> Specialities { get; }
        
        IRepository<Comment> Comments { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<City> Cities { get; }

        int SaveChanges();
    }
}
