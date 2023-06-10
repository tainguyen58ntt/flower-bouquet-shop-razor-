

using ClassLibrary1.DataAccess;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public class CustomerRepository : ICustomerRepository
        

    {
        public bool CheckDuplicateEmail(string email)
        {
			return CustomerManagement.Instance.GetCustomerByEmail(email) != null;
        }

        public Customer CheckLogin(string name, string password)
		{
			return CustomerManagement.Instance.GetByEmailAndPass(name, password);
		}

        public void DeleteCustomer(Customer customer)
        {
			 CustomerManagement.Instance.Remmove(customer);	
        }

        public void DeleteProduct(Customer cus) => CustomerManagement.Instance.Remmove(cus);


		public List<Customer> GetCustomer()
		{
			return CustomerManagement.Instance.GetCustomers();
		}

		public Customer GetCustomerById(Customer customer)
		{
			return CustomerManagement.Instance.GetByID(customer.CustomerId);
		}

		public Customer GetCustomerById(int? id)
		{
			return CustomerManagement.Instance.GetByID(id);
		}

		public List<Customer> GetCustomersByEmail(string email)
		{
			return CustomerManagement.Instance.GetCustomerByEmail(email);
		}

        public IEnumerable<Customer> GetIenumCustomers()
        {
           return CustomerManagement.Instance.GetIeumCustomers();	
        }

        public void InsertCustomer(Customer customer) => CustomerManagement.Instance.AddNew(customer);


		public void Update(Customer customer) => CustomerManagement.Instance.Update(customer);

	}
}
