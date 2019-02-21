using System.Collections.Generic;

namespace SelfHostedWebApi.Data.Abstracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Add(T item);
        bool Update(int id, T item);
        bool Delete(int id);
    }
}
