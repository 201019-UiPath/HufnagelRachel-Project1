using System;
using System.Collections.Generic;

namespace lacrosseDB.Models
{
    /// <summary>
    /// The class customer which inherits from the abstract products human
    /// </summary>
    public class Customer : Human 
    {

        /// <summary>
        /// Property of the customer class
        /// </summary>
        /// <value></value>
        public List<Orders> orders { get; set; }


    }
}
