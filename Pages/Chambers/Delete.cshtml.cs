using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shooting;

namespace Shooting.Pages_Chambers
{
    public class DeleteModel : PageModel
    {
        private readonly ShootingContext _context;

        public DeleteModel(ShootingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Chamber Chamber { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Chamber = await _context.Chamber.FirstOrDefaultAsync(m => m.ChamberID == id);

            if (Chamber == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Chamber = await _context.Chamber.FindAsync(id);

            if (Chamber != null)
            {
                _context.Chamber.Remove(Chamber);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
