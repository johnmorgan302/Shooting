using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shooting;

namespace Shooting.Pages_Firearms
{
    public class DeleteModel : PageModel
    {
        private readonly ShootingContext _context;

        public DeleteModel(ShootingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Firearm Firearm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Firearm = await _context.Firearm
                .Include(f => f.Manufacturer).FirstOrDefaultAsync(m => m.FirearmID == id);

            if (Firearm == null)
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

            Firearm = await _context.Firearm.FindAsync(id);

            if (Firearm != null)
            {
                _context.Firearm.Remove(Firearm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
