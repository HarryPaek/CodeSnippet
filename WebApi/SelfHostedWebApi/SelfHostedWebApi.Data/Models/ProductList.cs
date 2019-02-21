using System.Collections.Generic;
using System.Data;

namespace SelfHostedWebApi.Data.Models
{
    public class ProductList : List<Product>
    {
        #region Static Mathods

        public static ProductList ConvertFromDataTable(DataTable productTable)
        {
            ProductList list = new ProductList();

            if (productTable == null || productTable.Rows == null || productTable.Rows.Count == 0)
                return list;

            foreach (DataRow row in productTable.Rows)
            {
                list.Add(Product.ConvertFromDataRow(row));
            }

            return list;
        }

        #endregion
    }
}
