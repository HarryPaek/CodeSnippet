using System.Collections.Generic;

namespace ePlatform.Data.Abstracts
{
    public interface IRepository<TId, TItem> where TItem : IBaseEntity<TId>
    {
        IEnumerable<TItem> GetAll();

        TItem Get(TId id);

        TId Add(TItem item);

        bool Update(TId id, TItem item);

        bool Delete(TId id);
    }
}
