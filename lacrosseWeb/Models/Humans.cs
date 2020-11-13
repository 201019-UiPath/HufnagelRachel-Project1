using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using lacrosseDB.Models;

namespace lacrosseWeb.Models
{
    public class Humans
    {
        public int Id { get; set; }

        [Required]
        public int locationId { get; set; }
        public Locations location { get; set; }

        [Required]
        [RegularExpression(@"^[a-z0-9.]+@[a-z0-9]+[\.][a-z]")]
        public string email { get; set; }

        public List<Orders> orders { get; set; }

        public Cart cart { get; set; }
    }
}
