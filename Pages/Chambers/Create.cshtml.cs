using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shooting;

namespace Shooting.Pages_Chambers
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
            return Page();
        }

        [BindProperty]
        public Chamber Chamber { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Chamber.Add(Chamber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
