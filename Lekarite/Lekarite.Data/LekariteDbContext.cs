namespace Lekarite.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Lekarite.Data.Interfaces;
    using Lekarite.Data.Migrations;
    using Lekarite.Models;

    public class LekariteDbContext : IdentityDbContext<User>, ILekariteDbContext
    {
        public LekariteDbContext()
            : base("LekariteConnectionString", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LekariteDbContext, Configuration>());
        }
        
        public IDbSet<Doctor> Doctors { get; set; }

        public IDbSet<Speciality> Specialitites { get; set; }

        public IDbSet<Comment> Comments { get; set; }
        
        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<City> Cities { get; set; }

        public static LekariteDbContext Create()
        {
            return new LekariteDbContext();
        }
    }
}
