﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HelperlandTatvasoft.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int UserTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsApproved { get; set; }
    }
}
