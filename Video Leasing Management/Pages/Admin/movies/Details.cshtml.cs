using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages.Admin.movies
{
    public class DetailsModel : PageModel
    {
        private readonly VLM.Data.VLMDbContext _context;

        public DetailsModel(VLM.Data.VLMDbContext context)
        {
            _context = context;
        }

        public Movies Movies { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movies = await _context.Movies.FirstOrDefaultAsync(m => m.MoviesId == id);

            if (Movies == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
