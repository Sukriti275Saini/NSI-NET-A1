using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages.Admin.records
{
    public class EditModel : PageModel
    {
        private readonly VLM.Data.VLMDbContext _context;

        public EditModel(VLM.Data.VLMDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Records Records { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Records = await _context.Records.FirstOrDefaultAsync(m => m.RecordsId == id);

            if (Records == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Records).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordsExists(Records.RecordsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecordsExists(int id)
        {
            return _context.Records.Any(e => e.RecordsId == id);
        }
    }
}
