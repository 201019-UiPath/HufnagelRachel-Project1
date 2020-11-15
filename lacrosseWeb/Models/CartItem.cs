using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace lacrosseWeb.Models
{
    public class CartItem
    {
        public int stickId { get; set; }
        public Stick stick { get; set; }
        [DisplayName("Quantity")]
        public int quantity { get; set; }
    }
}
