using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly IVLMRepository repo;
        public IEnumerable<Records> UserRecords { get; set; }
        public string Username { get; set; }

        public IndexModel(IVLMRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult OnGet(string user)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) &&
                HttpContext.Session.GetString("username") != user)
            {
                return RedirectToPage("/Index");
            }
            Username = user;
            UserRecords = repo.GetRecordsByUsername(user);
            return Page();
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}