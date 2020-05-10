using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VLM.Data;
using VLM.Data.Models;

namespace Video_Leasing_Management.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IVLMRepository repo;
        [BindProperty] public Login LoginDetails { get; set; }
        public string Message { get; set; }

        public LoginModel(IVLMRepository repo)
        {
            this.repo = repo;
            LoginDetails = new Login();
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = repo.UserExist(LoginDetails.UserName, LoginDetails.Password);
                if (Message == "Successfull")
                {
                    HttpContext.Session.SetString("username", LoginDetails.UserName);
                    return RedirectToPage("/Dashboard/Index", new { user = LoginDetails.UserName });
                }
            }
            return Page();
        }
    }
}