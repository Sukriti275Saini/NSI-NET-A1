using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages.u
{
    public class IndexModel : PageModel
    {
        private readonly IVLMRepository repo;

        public IndexModel(IVLMRepository repo)
        {
            this.repo = repo;
        }

        public User UserData { get; set; }

        public IActionResult OnGet(string user)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) &&
                HttpContext.Session.GetString("username") != user)
            {
                return RedirectToPage("/Index");
            }
            UserData = repo.GetUserByUsername(user);
            return Page();
        }
    }
}
