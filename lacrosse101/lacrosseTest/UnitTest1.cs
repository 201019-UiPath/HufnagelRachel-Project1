using System.Collections.Generic;
using System.Linq;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using Xunit;

namespace lacrosseTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetAllCustomerShouldGetAllCustomers()
        {
            using var tester = new lacrosseContext();
            ICustomerRepo custRepo = new DBRepo(tester);
            List<Customer> custResult = custRepo.GetAllCustomers();
            Assert.NotNull(custResult);
        }

        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            using var tester = new lacrosseContext();
            ICustomerRepo custRepo = new DBRepo(tester);
            Customer newCust = new Customer();
            newCust.FirstName = "NewCustFirst";
            newCust.LastName = "NewCustLast";
            newCust.email = "newCust@gmail.com";
            newCust.LocationId = 2;

            custRepo.AddCustomer(newCust);
            Assert.NotNull(tester.Customer.Single(c => c.email == newCust.email));
            custRepo.DeleteACustomer(newCust);
        }

        // [Fact]
        // public void AddProductShouldAdd()
        // {
        //     using var TContext = new lacrosseContext();
        //     IProductRepo repo = new DBRepo(TContext);
        //     Product testerBall = new Balls(5.00, "Purple Lacrosse Ball");
        //     repo.AddProduct(testerBall);
        //     Assert.NotNull(TContext.Product.Single(b => b.description == testerBall.description));
        //     repo.DeleteProduct(testerBall);
        // }

        [Fact]
        public void GetAllManagersShouldGetAllManagers()
        {
            using var tester = new lacrosseContext();
            IManagerRepo repo = new DBRepo(tester);
            List<Manager> manResult = repo.GetAllManagers();
            Assert.NotNull(manResult);
        }

        [Fact]
        public void GetCustomerByEmailShouldGetCustomer()
        {
            using var testContext = new lacrosseContext();
            ICustomerRepo repo = new DBRepo(testContext);

            Customer test = new Customer();
            test.FirstName = "Test Name";
            test.LastName = "Test LName";
            test.email = "testUser@email.com";
            test.LocationId = 1;
            repo.AddCustomer(test);            

            Customer result = repo.GetCustomerByEmail(test.email);

            Assert.NotNull(result);

            repo.DeleteACustomer(test);
        }

        [Fact]
        public void UpdateCustomerShouldUpdateCustomer()
        {
            using var testContext = new lacrosseContext();
            ICustomerRepo repo = new DBRepo(testContext);
            
            Customer testUser = new Customer();
            testUser.FirstName = "Test Name";
            testUser.LastName = "Test LName";
            testUser.email = "testUser@email.com";
            testUser.LocationId = 1;
            repo.AddCustomer(testUser);

            testUser.LastName = "Different LName";
            repo.UpdateCustomer(testUser);
            var result = repo.GetCustomerByEmail(testUser.email);

            Assert.Equal("Different LName", result.LastName);

            repo.DeleteACustomer(testUser);
        }

        // [Fact]
        // public void AddOrderShouldAddOrder()
        // {
        //     using var test = new lacrosseContext();
        //     IOrderRepo repo = new DBRepo(test);
            
        // }

    }
}




