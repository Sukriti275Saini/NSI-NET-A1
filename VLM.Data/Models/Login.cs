using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLM.Data.Models
{
    public class Login
    {
        [Required]
        [StringLength(25, ErrorMessage = "Min:6, Max:25", MinimumLength = 6)]
        [RegularExpression("^[a-z._][a-z0-9._]*$", ErrorMessage = "only a-z, 0-9, wild characters(. and _) and not starts with a number")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Min:8, Max:20", MinimumLength = 8)]
        [RegularExpression(@"^[a-zA-Z0-9@*#]*$", ErrorMessage = "only a-z, A-Z, 0-9 and wild characters(*, @ and #)")]
        public string Password { get; set; }
    }
}
