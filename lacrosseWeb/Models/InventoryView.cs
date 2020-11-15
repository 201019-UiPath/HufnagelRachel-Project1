using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lacrosseWeb.Models
{
    public class InventoryView
    {
        [DisplayName("Name")]
        public string name { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a values greater than 0")]
        public int quantity { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Cost")]
        public decimal cost { get; set; }
        [DisplayName("Location")]
        public int locationId { get; set; }
        public int apiId { get; set; }
        public string imageURL { get; set; }
    }
}
