using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class User 
    {
        public int id { set; get; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please Enter Your Name.")]
        public string UserName { set; get; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage="Please Enter Your Email.")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Valid Email.")]
        public string Email { set; get; }

        [RegularExpression(@"[07](7|8|9)\d{8}",ErrorMessage = "Please Enter Valid Number")]
        public string Number { set; get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password fields do not match.")]
        [NotMapped]
        [Display(Name = "Re-enter Password")]
        public string ConfirmPassword { set; get; }

        public int UserRoleID { set; get; }
        [ForeignKey("UserRoleID")]
        public UserRoles UserRole { get; set; }

        public List<ComplaintRequest> ComplaintList { set; get; }

    }
}
