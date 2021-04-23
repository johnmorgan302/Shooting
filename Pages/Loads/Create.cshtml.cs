using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shooting;

namespace Shooting.Pages_Loads
{
    public class CreateModel : PageModel
    {
        private readonly ShootingContext _context;

        public CreateModel(ShootingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ChamberID"] = new SelectList(_context.Chamber, "ChamberID", "ChamberName");
            return Page();
        }

        [BindProperty]
        public LoadData LoadData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LoadData.Add(LoadData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
