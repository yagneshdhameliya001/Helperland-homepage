using System;
using System.Collections.Generic;

#nullable disable

namespace HelperlandTatvasoft.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
