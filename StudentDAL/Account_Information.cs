//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// model used for signup user
    /// </summary>
    public partial class Account_Information
    {
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter the username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "password cant be empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please specify the role")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Please enter the email")]
        public string Email { get; set; }
    }
}
