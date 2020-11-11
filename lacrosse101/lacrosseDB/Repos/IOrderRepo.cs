using System;
using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    public interface IOrderRepo
    {
        void AddOrder (Orders order);
        void UpdateOrder(Orders order);
        Orders GetOrderByOrderId(int orderId);
        Orders GetOrderByCustId(int custId);
        Orders GetOrderByLocationId (int locationId);
        List<Orders> GetAllOrdersByCustId(int custId);
        List<Orders> GetAllOrdersByLocationId (int locationId);
        void DeleteOrder(Orders order);

        void SaveChanges();

        List<Orders> GetAllOrdersByCustIdDateAsc(int custId);
        List<Orders> GettAllOrdersByCustIdDateDesc(int custId);
        List<Orders> GetAllOrdersByCustIdPriceAsc(int custId);
        List<Orders> GetAllOrdersByCustIdPriceDesc(int custId);
        Orders GetOrderByDate(DateTime dateTime);
    }
}