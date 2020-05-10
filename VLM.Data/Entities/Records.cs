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
        [Key] public int RecordsId { get; set; }
        [Required] public User User { get; set; }
        [Required] public Movies Movies { get; set; }
        [Required] public DateTime TakenDate { get; set; }
        [Required] public DateTime ReturnDate { get; set; }
    }
}
