namespace Lekarite.Data.Interfaces
{
    using System.Data.Entity;

    using Lekarite.Models;

    public interface ILekariteDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Doctor> Doctors { get; set; }

        IDbSet<Speciality> Specialitites { get; set; }

        IDbSet<Comment> Comments { get; set; }
        
        IDbSet<Rating> Ratings { get; set; }

        IDbSet<City> Cities { get; set; }
    }
}
