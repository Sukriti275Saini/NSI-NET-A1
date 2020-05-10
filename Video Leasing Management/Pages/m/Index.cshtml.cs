using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages.m
{
    public class IndexModel : PageModel
    {
        private readonly IVLMRepository repo;

        public IndexModel(IVLMRepository repo)
        {
            this.repo = repo;
        }

        public IList<Movies> AllMovies { get; private set; }

        public void OnGet()
        {
            AllMovies = repo.GetMovies().ToList();
        }
    }
}