using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Update(Product product);
        IResult Add(Product product);
        Product GetById(int productId);
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<ProductDetailDto> GetProductDetails();
    }
}
