using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    class CustomerManager

    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public bool IsNameExists(string name)
        {
            return _customerRepository.IsNameExists(name);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
        public bool Delete(Customer customer)
        {
            return _customerRepository.Delete(customer);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }
    }
}
