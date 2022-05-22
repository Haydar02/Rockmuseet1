using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rockmuseet.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rockmuseet.Interfaces;
using Rockmuseet.models;


namespace Rockmuseet
{
    public class UpdateHistoryModel : PageModel
    {
        [BindProperty]
        public List<History> histories { get; set; }
        private IHistoryRepository catalog;
        public History History { get; set; }

        public UpdateHistoryModel(IHistoryRepository repository)
        {
            catalog = repository;
        }

        public void OnGet(int id)
        {
            History = catalog.GetHistory(id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            catalog.UpdateHistory(History);
            return RedirectToPage("GetAllHistory");
        }
    }
}
