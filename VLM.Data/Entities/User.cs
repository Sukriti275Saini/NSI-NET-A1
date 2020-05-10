using System;
using System.ComponentModel.DataAnnotations;

namespace VLM.Data.Entities
{
    public class User
    {
        [Key]
        [Required]
        [Display(Name = "Username")]
        [StringLength(25, ErrorMessage = "Min:6, Max:25", MinimumLength = 6)]
        [RegularExpression(@"^[a-z._][a-z0-9._]*$", ErrorMessage = "only a-z, 0-9, wild characters(. and _) and not starts with a number")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Min:1, Max:30", MinimumLength = 1)]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "first capital rest small letters with no space")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Min:1, Max:30", MinimumLength = 1)]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "first capital rest small letters with no space")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [RegularExpression("^[a-z0-9._]+@[a-z0-9.-]+.[a-z]{2,}$", ErrorMessage = "it should be like example@example.com")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "number should be 10 digit long")]
        [DataType(DataType.PhoneNumber)]
        public long Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Min:8, Max:20", MinimumLength = 8)]
        [RegularExpression(@"^[a-zA-Z0-9@*#]*$", ErrorMessage = "only a-z, A-Z, 0-9, wild characters(@,*,#)")]
        public string Password { get; set; }
    }
}
