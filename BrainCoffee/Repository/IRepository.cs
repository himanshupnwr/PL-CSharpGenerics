using BrainCoffee.Entities;

namespace BrainCoffee.Repository
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : IEntity
    {
    }

    public interface IWriteRepository<in T>
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }

    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
