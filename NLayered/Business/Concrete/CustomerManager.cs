using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
    
        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public List<Customer> GetAllByCategoryId(int id)
        {
            return _customerDal.GetAll(c => c.CustomerId == id.ToString());
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }
    }
}
