using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using NorthWindCoreLibrary.Models;

namespace NorthWindCoreLibrary.Projections
{
    /// <summary>
    /// Purpose of this class is to return only data needed rather
    /// than bring in all properties e.g. without using projections
    /// Categories and Supplier properties would be loaded.
    /// </summary>
    public class Product : INotifyPropertyChanged
    {
        private string _productName;
        private short? _unitsInStock;
        private DateTime? _discontinuedDate;
        private string _categoryName;
        private int? _categoryId;
        private short? _reorderLevel;
        private short? _unitsOnOrder;
        private decimal? _unitPrice;
        private string _quantityPerUnit;
        private string _supplierName;
        private int? _supplierId;
        private int _productId;

        /// <summary>
        /// Primary key
        /// </summary>
        public int ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
                OnPropertyChanged();
            }
        }

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Primary key to supplier
        /// </summary>
        public int? SupplierId
        {
            get => _supplierId;
            set
            {
                _supplierId = value;
                OnPropertyChanged();
            }
        }

        public string SupplierName
        {
            get => _supplierName;
            set
            {
                _supplierName = value;
                OnPropertyChanged();
            }
        }

        public string QuantityPerUnit
        {
            get => _quantityPerUnit;
            set
            {
                _quantityPerUnit = value;
                OnPropertyChanged();
            }
        }

        public decimal? UnitPrice
        {
            get => _unitPrice;
            set
            {
                _unitPrice = value;
                OnPropertyChanged();
            }
        }

        public short? UnitsInStock
        {
            get => _unitsInStock;
            set
            {
                _unitsInStock = value;
                OnPropertyChanged();
            }
        }

        public short? UnitsOnOrder
        {
            get => _unitsOnOrder;
            set
            {
                _unitsOnOrder = value;
                OnPropertyChanged();
            }
        }

        public short? ReorderLevel
        {
            get => _reorderLevel;
            set
            {
                _reorderLevel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Category identifier for product
        /// </summary>
        public int? CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
                OnPropertyChanged();
            }
        }

        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                OnPropertyChanged();
            }
        }

        public DateTime? DiscontinuedDate
        {
            get => _discontinuedDate;
            set
            {
                _discontinuedDate = value;
                OnPropertyChanged();
            }
        }

        public override string ToString() => ProductName;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static Expression<Func<Products, Product>> Projection =>
            product => new Product()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierName = product.Supplier.CompanyName,
                SupplierId = product.SupplierId,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder, 
                CategoryId = product.CategoryId, 
                CategoryName = product.Category.CategoryName, 
                DiscontinuedDate = product.DiscontinuedDate
            };

    }

}
