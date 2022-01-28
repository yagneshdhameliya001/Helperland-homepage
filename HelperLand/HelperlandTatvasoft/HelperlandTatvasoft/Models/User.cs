using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HelperlandTatvasoft.Models
{
    public partial class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Mobile Number")]
        public string Mobile { get; set; }


        public int UserTypeId { get; set; }
    }
}
