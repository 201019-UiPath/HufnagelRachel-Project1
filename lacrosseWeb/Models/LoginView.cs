using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lacrosseWeb.Models
{
    public class LoginView
    {
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        public string email { get; set; }
    }
}
