namespace lacrosseDB.Models
{
    public class CartItem
    {
        /// <summary>
        /// Proterty of the cart item class
        /// </summary>
        /// <value></value>
        public int Id {get; set;}

        /// <summary>
        /// Proterty of the cart item class
        /// </summary>
        /// <value></value>
        public int cartId {get; set;} 

        /// <summary>
        /// Proterty of the cart item class
        /// </summary>
        /// <value></value>
        public Cart cart {get; set;}

        /// <summary>
        /// Proterty of the cart item class
        /// </summary>
        /// <value></value>
        public int stickId {get; set;}

        /// <summary>
        /// Proterty of the cart item class
        /// </summary>
        /// <value></value>
        public Sticks stick {get; set;} 

        /// <summary>
        /// Proterty of the cart item class
        /// </summary>
        /// <value></value>
        public int quantity {get; set;} 

        /// <summary>
        /// Proterty of the cart item class
        /// </summary>
        /// <value></value>
        public int custId {get; set;}
    }
}