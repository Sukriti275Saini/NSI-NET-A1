using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Video_Leasing_Management.Pages.Dashboard;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages.m
{
    public class DetailModel : PageModel
    {
        private readonly IVLMRepository repo;
        public Movies MovieData { get; set; }

        public DetailModel(IVLMRepository repo)
        {
            this.repo = repo;
        }

        public void OnGet(int mId)
        {
            MovieData = repo.GetMoviesById(mId);
        }

        public IActionResult OnPost(int mId)
        {
            var Username = HttpContext.Session.GetString("username");
            var MovieData = repo.GetMoviesById(mId);
            if (string.IsNullOrEmpty(Username))
            {
                return RedirectToPage("/Login");
            }
            var newRecord = new Records()
            {
                User = repo.GetUserByUsername(Username),
                Movies = MovieData,
                TakenDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(MovieData.ReturnDays)
            };
            repo.AddRecord(newRecord);
            repo.Commit();
            return RedirectToPage("/Dashboard/Index", new { user = Username });
        }
    }
}
