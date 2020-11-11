using System;
using System.Collections.Generic;

namespace lacrosseDB.Models
{
    /// <summary>
    /// The class orders which is neither inherited or extended by another class
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// Property of the orders class
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Property of the orders class
        /// </summary>
        /// <value></value>
        public List<Sticks> ItemsToBuy { get; set; }

        /// <summary>
        /// Property of the orders class
        /// </summary>
        /// <value></value>
        public double TotalPrice { get; set; }

        /// <summary>
        /// Property of the orders class
        /// </summary>
        /// <value></value>
        public int LocationId { get; set; }

        /// <summary>
        /// Property of the orders class
        /// </summary>
        /// <value></value>
        public Locations location { get; set; }

        /// <summary>
        /// Property of the orders class
        /// </summary>
        /// <value></value>
        public int CustomersId { get; set; }

        /// <summary>
        /// Property of the orders class
        /// </summary>
        /// <value></value>
        public Customer customer { get; set; }
        
        /// <summary>
        /// Property of the orders class
        /// </summary>
        /// <value></value>
        public DateTime dateOfOrder { get; set; }
    }
}