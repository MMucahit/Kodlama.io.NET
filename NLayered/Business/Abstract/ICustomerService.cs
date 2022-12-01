using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IResult Add(Customer customer);
        IDataResult<List<Customer>> GetAllByCategoryId(int id);
    }
}
