using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Message is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }
    }
}
}
