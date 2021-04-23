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
    public class DetailsModel : PageModel
    {
        private readonly ShootingContext _context;

        public DetailsModel(ShootingContext context)
        {
            _context = context;
        }

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
    }
}
