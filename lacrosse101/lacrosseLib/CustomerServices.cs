using System.Collections.Generic;
using lacrosseDB.Repos;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public class CustomerServices
    {
        private ICustomerRepo custRepo;

        public CustomerServices(ICustomerRepo custRepo)   
        {
            this.custRepo = custRepo;
        }

        public void AddCustomer(Customer customer) 
        {
            custRepo.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer) 
        {
            custRepo.UpdateCustomer(customer);
        }

        public Customer GetCustomerByCustId(int custId) 
        {
            Customer customer = custRepo.GetCustomerByCustId(custId);
            return customer;
        }

        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = custRepo.GetCustomerByEmail(email);
            return customer;
        }
 
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = custRepo.GetAllCustomers();
            return customers;
        }

        public void DeleteCustomer(Customer customer)
        {
            custRepo.DeleteACustomer(customer);
        }
    }
}