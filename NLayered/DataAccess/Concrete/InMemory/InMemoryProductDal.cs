using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products= new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Asus", UnitPrice=15000, UnitsInStock=10},
                new Product{ProductId=2, CategoryId=1, ProductName="Huawei", UnitPrice=17500, UnitsInStock=15},
                new Product{ProductId=3, CategoryId=2, ProductName="Samsunsg", UnitPrice=7500, UnitsInStock=30},
                new Product{ProductId=4, CategoryId=2, ProductName="IPhone", UnitPrice=25000, UnitsInStock=3},
                new Product{ProductId=5, CategoryId=3, ProductName="Mause", UnitPrice=5000, UnitsInStock=55}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _products.SingleOrDefault(filter.Compile());
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return (List<Product>)(filter == null
                ? _products.ToList()
                : _products.Where(filter.Compile()).ToList());
        }

        public void Update(Product product)
        {
            Product productToUpdate = null;
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.UnitsInStock= product.UnitsInStock;

            Console.WriteLine("Updated");
        }
    }
}
