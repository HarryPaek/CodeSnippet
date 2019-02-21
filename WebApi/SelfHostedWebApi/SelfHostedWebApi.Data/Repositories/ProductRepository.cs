using SelfHostedWebApi.Data.Abstracts;
using SelfHostedWebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfHostedWebApi.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly object _dbLock = new object();
        private readonly IDBAccessor _db;

        public ProductRepository(IDBAccessor dbAccessor)
        {
            if (dbAccessor == null)
                throw new ArgumentNullException("dbAccessor");

            this._db = dbAccessor;
        }

        #region IRepository Implementation

        public int Add(Product item)
        {
            int productId;

            lock (this._dbLock)
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

        public bool Delete(int id)
        {
            bool deleted = false;

            lock (this._dbLock)
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

        public Product Get(int id)
        {
            Product product = null;

            lock (this._dbLock)
            {
                try
                {
                    product = GetInternal(id);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            ProductList list = null;

            lock (this._dbLock)
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

        public bool Update(int id, Product item)
        {
            bool updated = false;

            lock (this._dbLock)
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

        #region Private Methods

        private ProductList GetAllInternal()
        {
            try
            {
                string commandText = @"SELECT *
                                         FROM dbo.Products";

                return ProductList.ConvertFromDataTable(this._db.ExecuteSelect(commandText));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Product GetInternal(int id)
        {
            try
            {
                string commandText = @"SELECT * 
                                         FROM dbo.Products
                                        WHERE ProductId     = @ProductId
                                        ORDER BY ProductId";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add("@ProductId", id);

                return ProductList.ConvertFromDataTable(this._db.ExecuteSelect(commandText, parameters)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int AddInternal(Product item)
        {
            try
            {
                string commandText = @"INSERT INTO dbo.Products(ProductName, ProductDescription)
                                       OUTPUT INSERTED.ProductId
                                       VALUES (@Name, @Description)";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add("@Name", item.Name);
                parameters.Add("@Description", item.Description);

                return (int)this._db.ExecuteScalar(commandText, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool UpdateInternal(int id, Product item)
        {
            try
            {
                string commandText = @"UPDATE dbo.Products
                                          SET ProductName        = @Name,
                                              ProductDescription = @Description
                                        WHERE ProductId          = @ProductId";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add("@Name", item.Name);
                parameters.Add("@Description", item.Description);
                parameters.Add("@ProductId", id);

                return this._db.ExecuteNonQuery(commandText, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool DeleteInternal(int id)
        {
            try
            {
                string commandText = @"DELETE dbo.Products
                                        WHERE ProductId          = @ProductId";

                Dictionary<string, object> parameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                parameters.Add("@ProductId", id);

                return this._db.ExecuteNonQuery(commandText, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
