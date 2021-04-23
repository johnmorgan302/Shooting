using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shooting;

namespace Shooting.Pages_Manufacturers
{
    public class DetailsModel : PageModel
    {
        private readonly ShootingContext _context;

        public DetailsModel(ShootingContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(m => m.ManufacturerID == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
