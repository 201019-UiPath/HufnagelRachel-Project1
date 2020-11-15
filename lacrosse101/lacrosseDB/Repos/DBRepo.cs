using System;
using System.Collections.Generic;
using System.Linq;
using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    /// <summary>
    /// The class which implements all the interfaces for the CRUD operations on the database
    /// </summary>
    public class DBRepo : ILineItemRepo, IProductRepo, ICustomerRepo, IManagerRepo, ILocationRepo, IInventoryRepo, IOrderRepo, ICartRepo, ICartItemsRepo
    {
        /// <summary>
        /// A Property of the DBRepo class 
        /// </summary>
        private lacrosseContext context;

        /// <summary>
        /// parameterized constructor 
        /// </summary>
        /// <param name="context"></param>
        public DBRepo(lacrosseContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// A method are for adding data to the database
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            context.Customer.Update(customer);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for adding data to the database
        /// </summary>
        /// <param name="location"></param>
        public void AddLocation(Locations location)
        {
            context.Locations.Update(location);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for adding data to the database
        /// </summary>
        /// <param name="manager"></param>
        public void AddManager(Manager manager)
        {
            context.Managers.Update(manager);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for adding data to the database
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Orders order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for adding data to the database
        /// </summary>
        /// <param name="inventory"></param>
        public void AddToInventory(Inventory inventory)
        {
            context.Inventory.Update(inventory);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for deleting data from the database
        /// </summary>
        /// <param name="customer"></param>
        public void DeleteACustomer(Customer customer)
        {
            context.Customer.Remove(customer);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for deleting data from the database
        /// </summary>
        /// <param name="location"></param>
        public void DeleteLocation(Locations location)
        {
            context.Locations.Remove(location);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for deleting data from the database
        /// </summary>
        /// <param name="manager"></param>
        public void DeleteManager(Manager manager)
        {
            context.Managers.Remove(manager);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for deleting data from the database
        /// </summary>
        /// <param name="order"></param>
        public void DeleteOrder(Orders order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for deleting data from the database
        /// </summary>
        /// <param name="inventory"></param>
        public void DeleteInventory(Inventory inventory)
        {
            context.Inventory.Remove(inventory);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            return context.Customer.Select(c => c).ToList();
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <returns></returns>
        public List<Locations> GetAllLocations()
        {
            return context.Locations.Select(l => l).ToList();
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <returns></returns>
        public List<Sticks> GetAllSticks()
        {
            List<Sticks> sticks = context.Product.Select(s => s).ToList();
            return sticks;
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <returns></returns>
        public List<Manager> GetAllManagers()
        {
            return context.Managers.Select(m => m).ToList();
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <returns></returns>
        public List<Inventory> GetAllOfInventoryByInventoryId(int inventoryId)
        {
            return context.Inventory.Where(i => i.Id == inventoryId).ToList();
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public List<Inventory> GetAllOfInventoryByLocationId(int locationId)
        {
            List<Inventory> inventories = context.Inventory.Where(i => i.LocationId == locationId).ToList();
            return inventories;
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public List<Orders> GetAllOrdersByLocationId(int locationId)
        {
            return context.Orders.Where(o => o.LocationId == locationId).ToList();
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public List<Orders> GetAllOrdersByCustId(int custId)
        {
            return context.Orders.Where(o => o.CustomersId == custId).ToList();
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public Customer GetCustomerByCustId(int custId)
        {
            return (Customer)context.Customer.Single(c => c.Id == custId);
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public Customer GetCustomerByEmail(string email)
        {
            return (Customer)context.Customer.Single(c => c.email == email);
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="intentoryId"></param>
        /// <returns></returns>
        public Inventory GetInventoryItemByInventoryId(int intentoryId)
        {
            return (Inventory) context.Inventory.Single(i => i.Id == intentoryId);
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public Inventory GetInventoryItemByLocationId(int locationId)
        {
            return (Inventory) context.Inventory.Single(i => i.LocationId == locationId);
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public Locations GetLocationByLocationId(int locationId)
        {
            return (Locations)context.Locations.Single(l => l.Id == locationId);
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="manId"></param>
        /// <returns></returns>
        public Manager GetManagerByManId(int manId)
        {
            return (Manager)context.Managers.Single(m => m.Id == manId);
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public Manager GetManagerByEmail(string email)
        {
            return (Manager)context.Managers.Single(m => m.email == email);
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public Orders GetOrderByCustId(int custId)
        {
            return (Orders)context.Orders.Single(o => o.CustomersId == custId);
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public Orders GetOrderByLocationId(int locationId)
        {
            return (Orders)context.Orders.Single(o => o.LocationId == locationId);
        }
        /// <summary>
        /// A method are for retreving data from the database
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Orders GetOrderByOrderId(int orderId)
        {
            return (Orders)context.Orders.Single(o => o.Id == orderId);
        }

        /// <summary>
        /// A method are for updating data from the database
        /// </summary>
        /// <param name="customer"></param>
        public void UpdateCustomer(Customer customer)
        {
            context.Customer.Update(customer);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for updating data from the database
        /// </summary>
        /// <param name="inventory"></param>
        public void UpdateInventory(Inventory inventory)
        {
            context.Inventory.Update(inventory);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for updating data from the database
        /// </summary>
        /// <param name="location"></param>
        public void UpdateLocation(Locations location)
        {
            context.Locations.Update(location);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for updating data from the database
        /// </summary>
        /// <param name="manager"></param>
        public void UpdateManager(Manager manager)
        {
            context.Managers.Update(manager);
            context.SaveChanges();
        }
        /// <summary>
        /// A method are for updating data from the database
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrder(Orders order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }
        /// <summary>
        /// A method for adding data to the database 
        /// </summary>
        /// <param name="cart"></param>
        public void AddCart(Cart cart)
        {
            context.Cart.Update(cart);
            context.SaveChanges();
        }
        /// <summary>
        /// A method for updating data from the database 
        /// </summary>
        /// <param name="cart"></param>
        public void UpdateCart(Cart cart)
        {
            context.Cart.Update(cart);
            context.SaveChanges();
        }
        /// <summary>
        /// A method for retreving data from the database
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public Cart GetCartByCartId(int cartId)
        {
            Cart cart = context.Cart.Single(ct => ct.Id == cartId);
            return cart;
        }
        /// <summary>
        /// A method for retreving data from the database
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public Cart GetCartByCustId(int custId)
        {
            Cart cart = context.Cart.Single(ct => ct.custId == custId);
            return cart;
        }
        /// <summary>
        /// A method for deleting data from the database
        /// </summary>
        /// <param name="cart"></param>
        public void DeleteCart(Cart cart)
        {
            context.Cart.Remove(cart);
            context.SaveChanges();
        }
        /// <summary>
        /// A method for adding data to the database
        /// </summary>
        /// <param name="cartItem"></param>
        public void AddCartItem(CartItem cartItem)
        {
            context.CartItem.Update(cartItem);
            context.SaveChanges();
        }
        /// <summary>
        /// A method for updating data in the database
        /// </summary>
        /// <param name="cartItem"></param>
        public void UpdateCartItem(CartItem cartItem)
        {
            context.CartItem.Update(cartItem);
            context.SaveChanges();
        }
        /// <summary>
        /// A method for retreving data from the database
        /// </summary>
        /// <param name="cartItemId"></param>
        /// <returns></returns>
        public CartItem GetCartItemByCartItemId(int cartItemId)
        {
            CartItem cartItem = context.CartItem.Single(ci => ci.Id == cartItemId);
            return cartItem;
        }
        /// <summary>
        /// A method for retreving data from the database
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public CartItem GetCartItemByCartId(int cartId)
        {
            CartItem cartItem = context.CartItem.Single(ci => ci.cartId == cartId);
            return cartItem;
        }
        /// <summary>
        /// A method for retreving data from the database 
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public List<CartItem> GetAllCartItemsByCartId(int cartId)
        {
            List<CartItem> cartItems = context.CartItem.Where(ci => ci.cartId == cartId).ToList();
            return cartItems;
        }

        /// <summary>
        /// A method for retreving data from the database 
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public CartItem GetCartItemByCustId(int custId)
        {
            CartItem cartItem = context.CartItem.Single(ci => ci.custId == custId);
            return cartItem;
        }
        /// <summary>
        /// A method for deleting data from the database 
        /// </summary>
        /// <param name="cartItem"></param>
        public void DeleteCartItem(CartItem cartItem)
        {
            context.CartItem.Remove(cartItem);
            context.SaveChanges();
        }

        /// <summary>
        /// Sort the orders by date for a specific customer asc
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        List<Orders> IOrderRepo.GetAllOrdersByCustIdDateAsc(int custId)
        {
            return context.Orders.Where(x => x.CustomersId == custId).OrderBy(x => x.dateOfOrder).ToList();
        }

        /// <summary>
        /// Sort the orders by date for a specific customer desc
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        List<Orders> IOrderRepo.GettAllOrdersByCustIdDateDesc(int custId)
        {
            return context.Orders.Where(x => x.CustomersId == custId).OrderByDescending(x => x.dateOfOrder).ToList();
        }

        /// <summary>
        /// Sort the orders by price for a specific customer
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        List<Orders> IOrderRepo.GetAllOrdersByCustIdPriceAsc(int custId)
        {
            return context.Orders.Where(x => x.CustomersId == custId).OrderBy(x => x.TotalPrice).ToList();
        }

        /// <summary>
        /// Sort the orders by price for a specific customer
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        List<Orders> IOrderRepo.GetAllOrdersByCustIdPriceDesc(int custId)
        {
            return context.Orders.Where(x => x.CustomersId == custId).OrderByDescending(x => x.TotalPrice).ToList();
        }

        /// <summary>
        /// Get a orders by date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        Orders IOrderRepo.GetOrderByDate(DateTime dateTime)
        {
            return (Orders) context.Orders.Single(x => x.dateOfOrder == dateTime);
        }

        Manager IManagerRepo.GetManagerByLocationId(int locID)
        {
            return (Manager) context.Managers.Single(m => m.LocationId == locID);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void AddStick(Sticks stick)
        {
            context.Product.Add(stick);
            context.SaveChanges();
        }

        public void DeleteStick(Sticks stick)
        {
            context.Product.Remove(stick);
            context.SaveChanges();
        }

        public Sticks GetProductByStickId(int Id)
        {
            return (Sticks) context.Product.Single(s => s.Id == Id);
        }

        public void AddLineItem(lineItem lineItem)
        {
            context.LineItem.Add(lineItem);
            context.SaveChanges();
        }

        public void UpdateLineItem(lineItem lineItem)
        {
            context.LineItem.Update(lineItem);
            context.SaveChanges();
        }

        public lineItem GetLineItemByOrderId(int orderId)
        {
            return (lineItem)context.LineItem.Single(li => li.orderId == orderId);
        }

        public List<lineItem> GetAllLineItemsByOrderId(int orderId)
        {
            List<lineItem> lineitems = context.LineItem.Where(li => li.orderId == orderId).ToList();
            return lineitems;
        }

        public void DeleteLineItem(lineItem lineItem)
        {
            context.LineItem.Remove(lineItem);
            context.SaveChanges();
        }

        Inventory IInventoryRepo.GetInventoryByLocIdStickId(int locId, int stickId)
        {
            return (Inventory)context.Inventory.Single(i => i.LocationId == locId && i.stickId == stickId);
        }

        public void UpdateStick(Sticks stick)
        {
            context.Product.Update(stick);
            context.SaveChanges();
        }
    }
}