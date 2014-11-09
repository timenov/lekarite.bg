namespace Lekarite.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Lekarite.Data.Interfaces;
    using Lekarite.Data.Repository;
    using Lekarite.Models;

    public class LekariteData : ILekariteData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public LekariteData()
            : this(new LekariteDbContext())
        {
        }

        public LekariteData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Doctor> Doctors
        {
            get { return this.GetRepository<Doctor>(); }
        }

        public IRepository<Speciality> Specialities
        {
            get { return this.GetRepository<Speciality>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Rating> Ratings
        {
            get { return this.GetRepository<Rating>(); }
        }

        public IRepository<City> Cities
        {
            get { return this.GetRepository<City>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(EFRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
