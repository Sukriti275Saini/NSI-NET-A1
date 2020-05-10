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
    public class DeleteModel : PageModel
    {
        private readonly IVLMRepository repo;

        public DeleteModel(IVLMRepository repo)
        {
            this.repo = repo;
        }

        [BindProperty] public User UserData { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet(string user)
        {
            UserData = repo.GetUserByUsername(user);
            Message = repo.Delete(user);
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) &&
                HttpContext.Session.GetString("username") != user)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public IActionResult OnPost(string user)
        {
            string Mes = repo.Delete(user);
            if (Mes == "Successfull")
            {
                repo.Commit();
                HttpContext.Session.Clear();
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
