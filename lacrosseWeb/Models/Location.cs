using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lacrosseWeb.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string StoreLocation { get; set; }
        public List<Inventory> inventory { get; set; }
        public string GetLocation()
        {
            return $"{StoreLocation}";
        }
    }
}
