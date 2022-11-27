using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductLenghtError);
            }
            _productDal.Add(product);
            // Parametreli true default geliyor. Birde mesaj dönderiyoruz.
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Product product)
        {
            if (product.ProductName == null)
            {
                //return new ErrorResult(); // Parametresiz sadece false
                return new ErrorResult(Messages.ProductRequired);
            }
            _productDal.Update(product);
            // Parametresiz sadece true
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            // İş kodları (Yetkisi var mı gibi.)
            //if("if Someting happen" == "")
            //{
            //    return new ErrorDataResult<List<Product>>();
            //}
            
            return new SuccessDataResult<List<Product>>
                (_productDal.GetAll(),true, Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            //if ("if Someting happen" == "")
            //{
            //    return new ErrorDataResult<List<Product>>();
            //}

            return new SuccessDataResult<List<Product>>
                (_productDal.GetAll(p => p.CategoryId == id), true, Messages.ProductListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            //if ("if Someting happen" == "")
            //{
            //    return new ErrorDataResult<Product>();
            //}

            return new SuccessDataResult<Product>
                (_productDal.Get(p => p.ProductId == productId), true, Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //if ("if Someting happen" == "")
            //{
            //    return new ErrorDataResult<List<ProductDetailDto>>();
            //}

            return new SuccessDataResult<List<ProductDetailDto>>
                (_productDal.GetProductDetails(),true, Messages.ProductListed);
        }

    }
}
