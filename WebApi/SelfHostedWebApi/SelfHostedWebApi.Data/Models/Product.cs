using SelfHostedWebApi.Common.Abstracts;
using SelfHostedWebApi.Common.Extensions;
using System;
using System.Data;

namespace SelfHostedWebApi.Data.Models
{
    public class Product
    {
        #region Static Mathods

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion

        #region Public Mathods

        public override string ToString()
        {
            return string.Format("{0,7}, {1}, {2}", this.Id, this.Name, this.Description);
        }

        #endregion

        #region Static Mathods

        public static Product ConvertFromDataRow(DataRow productRow)
        {
            if (productRow == null)
                throw new ArgumentNullException("productRow");

            Product product = new Product
            {
                Id = productRow.Field<int>("ProductId"),
                Name = productRow.SafeGetString("ProductName"),
                Description = productRow.SafeGetString("ProductDescription")
            };

            return product;
        }

        public static Product Empty
        {
            get { return _empty; }
        }

        #region Private Static Methods

        private static Product _empty = new Product
        {
            Id = -1,
            Name = string.Empty,
            Description = string.Empty
        };

        #endregion

        #endregion
    }
}
