using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace lacrosseWeb.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int stickId { get; set; }
        public Stick stick { get; set; }
        public int locationId { get; set; }
        public Location location { get; set; }
        [DisplayName("Quantity")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Integer must be Positive")]
        [Range(1,50, ErrorMessage = "Quantity must lie between 1 and 50")]
        public int quantity { get; set; }
    }
}
