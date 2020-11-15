using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseDB.Models;
using System.Collections.Generic;
using System;

namespace lacrosseLib
{
    public class OrderServices : IOrderServices
    {
        private IOrderRepo orderRepo;

        public OrderServices(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        public void AddOrder(Orders order)
        {
            orderRepo.AddOrder(order);
        }


        public void UpdateOrder(Orders order)
        {
            orderRepo.UpdateOrder(order);
        }

        public Orders GetOrderByOrderId(int orderId)
        {
            Orders order = orderRepo.GetOrderByOrderId(orderId);
            return order;
        }

        public Orders GetOrderByCustId(int custId)
        {
            Orders order = orderRepo.GetOrderByCustId(custId);
            return order;
        }

        public Orders GetOrderByLocationId(int locationId)
        {
            Orders order = orderRepo.GetOrderByLocationId(locationId);
            return order;
        }

        public List<Orders> GetAllOrdersByCustId(int custId)
        {
            List<Orders> orders = orderRepo.GetAllOrdersByCustId(custId);
            return orders;
        }

        public List<Orders> GetAllOrdersByLocationId(int locationId)
        {
            List<Orders> orders = orderRepo.GetAllOrdersByLocationId(locationId);
            return orders;
        }

        public void DeleteOrder(Orders order)
        {
            orderRepo.DeleteOrder(order);
        }

        public List<Orders> GetAllOrdersByCustIdDateAsc(int custId)
        {
            List<Orders> orders = orderRepo.GetAllOrdersByCustIdDateAsc(custId);
            return orders;
        }
        public List<Orders> GettAllOrdersByCustIdDateDesc(int custId)
        {
            List<Orders> orders = orderRepo.GettAllOrdersByCustIdDateDesc(custId);
            return orders;
        }
        public List<Orders> GetAllOrdersByCustIdPriceAsc(int custId)
        {
            List<Orders> orders = orderRepo.GetAllOrdersByCustIdPriceAsc(custId);
            return orders;
        }
        public List<Orders> GetAllOrdersByCustIdPriceDesc(int custId)
        {
            List<Orders> orders = orderRepo.GetAllOrdersByCustIdPriceDesc(custId);
            return orders;
        }
        public Orders GetOrderByDate(DateTime dateTime)
        {
            Orders order = orderRepo.GetOrderByDate(dateTime);
            return order;
        }


    }
}