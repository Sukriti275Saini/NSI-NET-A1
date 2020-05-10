using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VLM.Data;
using VLM.Data.Entities;

namespace Video_Leasing_Management.Pages.Dashboard
{
    public class ReturnModel : PageModel
    {
        private readonly IVLMRepository repo;
        public Records UserRecord { get; set; }

        public ReturnModel(IVLMRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult OnGet(int rId)
        {
            string User = HttpContext.Session.GetString("username");
            UserRecord = repo.GetRecordsById(rId);
            if (string.IsNullOrEmpty(User) && UserRecord == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public IActionResult OnPost(int rId)
        {
            string User = HttpContext.Session.GetString("username");
            var SingleRecord = repo.GetRecordsById(rId);
            bool resp = repo.DeleteRecord(SingleRecord);
            if (resp)
            {
                repo.Commit();
                return RedirectToPage("./Index", new { user = User });
            }
            return Page();
        }
    }
}