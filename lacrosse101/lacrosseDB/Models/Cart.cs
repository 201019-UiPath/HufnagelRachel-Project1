using System.Collections.Generic;

namespace lacrosseDB.Models
{
    public class Cart
    {
        /// <summary>
        /// Property of the cart clas
        /// </summary>
        /// <value></value>
        public int Id {get; set;}

        /// <summary>
        /// Property of the cart class
        /// </summary>
        /// <value></value>
        public int custId {get; set;} 

        /// <summary>
        /// Proterty of the cart class
        /// </summary>
        /// <value></value>
        public Customer customer {get; set;}


        /// <summary>
        /// Property of the cart class
        /// </summary>
        /// <value></value>
        public List<CartItem> cartItem {get; set;} 
    }
}