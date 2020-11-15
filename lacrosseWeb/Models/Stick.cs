using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lacrosseWeb.Models
{
    public class Stick
    {
        public int Id { get; set; }
        public string name { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Cost")]
        public int cost { get; set; }
        public string description { get; set; }
        public string apiId { get; set; }
        public string imageURL { get; set; }
    }
}
