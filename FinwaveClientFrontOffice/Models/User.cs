using FinwaveClientFrontOffice.Common;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "The Password should contains one small letter, one capital letter and one number.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "The Conform Password field is required.")]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string ConformPassword { get; set; }
        [EmailAddress(ErrorMessage = "Please enter correct email address")]
        public string EmailId { get; set; }
        public bool IsAdmin { get; set; }
        public int RoleID { get; set; }
        public bool IsPassValid { get; set; }
        [Required(ErrorMessage = "The ClientCode field is required.")]
        public string ClientCode { get; set; }
        public string MobileOtp { get; set; }
        public string CapchaCode { get; set; }
        public string ReceiveType { get; set; }

    }

    public class UserResponse : Response
    {
        public User oUser { get; set; }
    }
}