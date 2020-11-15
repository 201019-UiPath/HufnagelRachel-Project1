using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lacrosseWeb.Models
{
    public class Cart
    {
        public List<CartItem> cartItems { get; set; }
        [DataType(DataType.Currency)]
        public decimal totalCost { get; set; }
        public Cart()
        {
            cartItems = new List<CartItem>();
        }
    }
}
