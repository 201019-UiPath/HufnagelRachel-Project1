using System;
using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public interface IOrderServices
    {
        void AddOrder(Orders order);
        void DeleteOrder(Orders order);
        List<Orders> GetAllOrdersByCustId(int custId);
        List<Orders> GetAllOrdersByCustIdDateAsc(int custId);
        List<Orders> GetAllOrdersByCustIdPriceAsc(int custId);
        List<Orders> GetAllOrdersByCustIdPriceDesc(int custId);
        List<Orders> GetAllOrdersByLocationId(int locationId);
        Orders GetOrderByCustId(int custId);
        Orders GetOrderByDate(DateTime dateTime);
        Orders GetOrderByLocationId(int locationId);
        Orders GetOrderByOrderId(int orderId);
        List<Orders> GettAllOrdersByCustIdDateDesc(int custId);
        void UpdateOrder(Orders order);
    }
}