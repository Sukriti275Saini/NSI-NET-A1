using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages.u
{
    public class EditModel : PageModel
    {
        private readonly IVLMRepository repo;

        public EditModel(IVLMRepository repo)
        {
            this.repo = repo;
        }

        [BindProperty]
        public User UserData { get; set; }

        public IActionResult OnGet(string user)
        {
            UserData = repo.GetUserByUsername(user);
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) &&
                HttpContext.Session.GetString("username") != user)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                repo.Update(UserData);
                repo.Commit();
                return RedirectToPage("./Index", new { user = UserData.UserName });
            }
            return Page();
        }

    }
}
