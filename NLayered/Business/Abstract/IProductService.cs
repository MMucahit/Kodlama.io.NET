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
        List<Product> GetAll();
        void Update(Product product);
        List<Product> GetAllByCategoryId(int id);
        List<ProductDetailDto> GetProductDetails();
    }
}
