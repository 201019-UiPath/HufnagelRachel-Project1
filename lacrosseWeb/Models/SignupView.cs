using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lacrosseWeb.Models
{
    public class SignupView
    {
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        public string email { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Fist Name")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int locationId { get; set; }
        public List<SelectListItem> locationOptions { get; set; }
    }
}
