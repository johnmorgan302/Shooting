using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shooting;

namespace Shooting.Pages_Loads
{
    public class DeleteModel : PageModel
    {
        private readonly ShootingContext _context;

        public DeleteModel(ShootingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoadData LoadData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoadData = await _context.LoadData
                .Include(l => l.Chamber).FirstOrDefaultAsync(m => m.LoadID == id);

            if (LoadData == null)
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

            LoadData = await _context.LoadData.FindAsync(id);

            if (LoadData != null)
            {
                _context.LoadData.Remove(LoadData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
