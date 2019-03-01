using ePlatform.Data.Abstracts;
using System;
using System.Collections.Generic;

namespace ePlatform.Data.Repositories
{
    public abstract class AbstractRepositoryBase<TId, TItem> : IRepository<TId, TItem> where TItem : IBaseEntity<TId>
    {
        #region IRepository

        public virtual TId Add(TItem item)
        {
            TId itemId;

            lock (this.LockObject)
            {
                try
                {
                    itemId = AddInternal(item);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return itemId;
        }

        public virtual bool Delete(TId id)
        {
            bool deleted = false;

            lock (this.LockObject)
            {
                try
                {
                    deleted = DeleteInternal(id);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return deleted;
        }

        public virtual TItem Get(TId id)
        {
            TItem item = default(TItem);

            lock (this.LockObject)
            {
                try
                {
                    item = GetInternal(id);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return item;
        }

        public virtual IEnumerable<TItem> GetAll()
        {
            IEnumerable<TItem> list = null;

            lock (this.LockObject)
            {
                try
                {
                    list = GetAllInternal();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return list;
        }

        public virtual bool Update(TId id, TItem item)
        {
            bool updated = false;

            lock (this.LockObject)
            {
                try
                {
                    updated = UpdateInternal(id, item);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return updated;
        }

        #endregion

        #region Abstracted Abstract Properties

        protected abstract object LockObject  { get; }

        #endregion

        #region Abstracted Abstract Methods

        protected abstract IEnumerable<TItem> GetAllInternal();

        protected abstract TItem GetInternal(TId id);

        protected abstract TId AddInternal(TItem item);

        protected abstract bool UpdateInternal(TId id, TItem item);

        protected abstract bool DeleteInternal(TId id);

        #endregion
    }
}
