using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    // Bir iş sınıfı başka sınıfları new lemez. Constructr Injection yapılır.
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        // ProductManager new lendiğinde IProductDal referansı ister.
        // Bu inMemory de olabilir. Entityframework de olabilir.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // İş kodları (Yetkisi var mı gibi.)
            return _productDal.GetAll();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
