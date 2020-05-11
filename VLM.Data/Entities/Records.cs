using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLM.Data.Entities
{
    public class Records
    {
        [Key]
        [Display(Name = "Record Id")]
        public int RecordsId { get; set; }

        [Required]
        [Display(Name = "Username")]
        public User User { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public Movies Movies { get; set; }

        [Required]
        [Display(Name = "Issue Date")]
        public DateTime TakenDate { get; set; }

        [Required]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
    }
}
