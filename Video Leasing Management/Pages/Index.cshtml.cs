using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages
{
    public class IndexModel : PageModel
    {     
        
    public IActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                return RedirectToPage("/m/List");
            }
            return Page();
        }
    }
}
