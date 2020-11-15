using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lacrosseWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("LastName")]
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        [DisplayName("Email Address")]
        [Required]
        public string email { get; set; }
        public int locationId { get; set; }
        public Location location { get; set; }
        public List<Order> orders { get; set; }
        public Cart cart { get; set; }
        public Customer()
        {
            cart = new Cart();
        }
    }
}
