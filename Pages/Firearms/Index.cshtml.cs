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
    public class IndexModel : PageModel
    {
        private readonly ShootingContext _context;

        public IndexModel(ShootingContext context)
        {
            _context = context;
        }

        public IList<Firearm> Firearm { get;set; }

        public async Task OnGetAsync()
        {
            Firearm = await _context.Firearm
                .Include(f => f.Manufacturer).ToListAsync();
        }
    }
}
