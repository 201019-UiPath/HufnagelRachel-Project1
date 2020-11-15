using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public interface ICustomerServices
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerByCustId(int custId);
        Customer GetCustomerByEmail(string email);
        void UpdateCustomer(Customer customer);
    }
}