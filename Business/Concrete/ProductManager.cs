using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        // Bir Manager kendisi hariç Dal ı enjekte edemez.
        IProductDal _productDal;
        ICategoryService _categoryService;

        // ProductManager new lendiğinde IProductDal referansı ister.
        // Bu inMemory de olabilir. Entityframework de olabilir.
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Business codes

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategory(product),
                CheckIfProductNameExists(product),
                CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

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

        private IResult CheckIfProductNameExists(Product product)
        {
            bool result = _productDal.GetAll(p => p.ProductName == product.ProductName).Any();
            if (!result)
            {
                return new ErrorResult(Messages.ProductNameAlreadtExistError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductCountOfCategory(Product product)
        {
            int numberOfCategory = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (numberOfCategory >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            int numberOfCategory = _categoryService.GetAll().Data.Count();
            if (numberOfCategory >= 15)
            {
                return new ErrorResult(Messages.CategoryLimitError);
            }

            return new SuccessResult();
        }
    }
}
