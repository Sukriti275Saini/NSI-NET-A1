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
    public class IndexModel : PageModel
    {
        private readonly IVLMRepository _context;

        public IndexModel(IVLMRepository context)
        {
            _context = context;
        }

        public IList<Records> Records { get; set; }

        public void OnGet()
        {
            Records = _context.GetAllRecords().ToList();
        }
    }
}
