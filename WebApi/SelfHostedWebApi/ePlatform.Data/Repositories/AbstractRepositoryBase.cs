using ePlatform.Data.Abstracts;
using System;
using System.Collections.Generic;

namespace ePlatform.Data.Repositories
{
    public abstract class AbstractRepositoryBase<TId, TItem> : IRepository<TId, TItem> where TItem : IBaseEntity<TId>
    {
        private readonly object _lockObject = new object();

        #region IRepository

        public virtual TId Add(TItem item)
        {
            TId productId;

            lock (this._lockObject)
            {
                try
                {
                    productId = AddInternal(item);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return productId;
        }

        public virtual bool Delete(TId id)
        {
            bool deleted = false;

            lock (this._lockObject)
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

            lock (this._lockObject)
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

            lock (this._lockObject)
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

            lock (this._lockObject)
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

        #region Abstracted Abstract Methods

        protected abstract IEnumerable<TItem> GetAllInternal();

        protected abstract TItem GetInternal(TId id);

        protected abstract TId AddInternal(TItem item);

        protected abstract bool UpdateInternal(TId id, TItem item);

        protected abstract bool DeleteInternal(TId id);

        #endregion
    }
}
