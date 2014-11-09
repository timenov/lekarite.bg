namespace Lekarite.Data.Interfaces
{
    using System;
    using System.Linq;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(object id);

        void Delete(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}
