using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        void Update(Customer customer);
        List<Customer> GetAllByCategoryId(int id);
    }
}
