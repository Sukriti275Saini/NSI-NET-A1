using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VLM.Data;
using VLM.Data.Entities;
using VLM.Data.Models;

namespace Video_Leasing_Management.Pages
{
    public class SignupModel : PageModel
    {
        private readonly IVLMRepository repo;
        [BindProperty]
        public User SignupDetails { get; set; }
        public string Message { get; set; }
        public SignupModel(IVLMRepository repo)
        {
            this.repo = repo;
            SignupDetails = new User();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = repo.Add(SignupDetails);
                if (Message == "Successfull")
                {
                    repo.Commit();
                    HttpContext.Session.SetString("username", SignupDetails.UserName);
                    return RedirectToPage("/Dashboard/Index", new { user = SignupDetails.UserName });
                }
            }
            return Page();
        }
    }
}