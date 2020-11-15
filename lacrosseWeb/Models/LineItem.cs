using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lacrosseDB.Models;

namespace lacrosseWeb.Models
{
    public class LineItem
    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public Orders order { get; set; }
        public int stickId { get; set; }
        public Sticks stick { get; set; }
        public int quantity { get; set; }
        public decimal cost { get; set; }
    }
}
