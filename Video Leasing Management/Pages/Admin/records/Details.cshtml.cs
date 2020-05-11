using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages.Admin.records
{
    public class DetailsModel : PageModel
    {
        private readonly IVLMRepository _context;

        public DetailsModel(IVLMRepository context)
        {
            _context = context;
        }

        public Records Records { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id < 0)
            {
                return RedirectToPage("Index");
            }

            Records = _context.GetRecordsById(id, true);

            if (Records == null)
            {
                NotFound();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
