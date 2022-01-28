using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HelperlandTatvasoft.Models
{
    public partial class Contact
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Please enter Last name")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Please enter Phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public long PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage ="Enter Proper Email")]
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter Message")]
        public string Message { get; set; }
    }
}
