using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lacrosseWeb.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int custId { get; set; }
        public Customer customer { get; set; }
        public int locationId { get; set; }
        public Location location { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Order Date")]
        public DateTime dateOfOrder { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Total")]
        public decimal totalCost { get; set; }
        public List<LineItem> lineItems { get; set; }
    }
}
