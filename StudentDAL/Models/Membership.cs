using StudentDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// model used for checking login credentials
/// </summary>

namespace StudentPortal.Models
{
    public class Membership
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class SignUpViewModel
    {
        public Account_Information account_Information { get; set; }

    }
}