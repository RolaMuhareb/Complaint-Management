using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComplaintManagement.Models
{
    public class UserDTO
    {
        public int? id { set; get; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please Enter Your Name.")]
        public string UserName { set; get; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Your Email.")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Valid Email.")]
        public string Email { set; get; }
        [RegularExpression(@"[07](7|8|9)\d{8}", ErrorMessage = "Please Enter Valid Number")]
        public string Number { set; get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password fields do not match.")]
        [NotMapped]
        [Display(Name = "Re-enter Password")]
        public string ConfirmPassword { set; get; }
    }
}