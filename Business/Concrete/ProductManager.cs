using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    // Validation işlemleri burada yazılmaz. Gelen verinin kontrolü. Şifre 5 harfli olmalı gibi
    // İş kodlaru burada yazılır mesela kişi ehliyet alması için gereksinimleri karşılıyor mu gibi
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>
                (_productDal.GetAll(), true, Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>
                (_productDal.GetAll(p => p.CategoryId == id), true, Messages.ProductListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>
                (_productDal.Get(p => p.ProductId == productId), true, Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>
                (_productDal.GetProductDetails(), true, Messages.ProductListed);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult("Delete");
        }
    }
}
