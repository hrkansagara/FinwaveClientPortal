﻿using System.ComponentModel.DataAnnotations;

namespace FinwaveClientFrontOffice.Models
{
    public class User
    {
        public int EmployeeId { get; set; }
        public string ProfilePic { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public bool IsActive { get; set; }
        public int ClientID { get; set; }
        public string Mobile { get; set; }
        public string UserFullName { get; set; }
        public bool IsChangePassword { get; set; }
        [Required(ErrorMessage = "The Username field is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Please enter correct email address")]
        public string EmailId { get; set; }
        public bool IsAdmin { get; set; }
        public int RoleID { get; set; }
        public bool IsPassValid { get; set; }
    }
}