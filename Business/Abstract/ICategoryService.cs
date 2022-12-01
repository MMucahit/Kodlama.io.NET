using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);
        IResult Update(Category category);
        IResult Delete(Category category);
        IResult Add(Category category);
        IDataResult<List<Category>> GetAllByCategoryId(int id);
    }
}
