using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    public interface ICustomerRepo 
    {
        void AddCustomer (Customer customer);
        void UpdateCustomer (Customer customer);
        Customer GetCustomerByCustId (int custId);
        Customer GetCustomerByEmail (string email);
        List <Customer> GetAllCustomers();
        void DeleteACustomer (Customer customer);

        void SaveChanges();

    }
}
