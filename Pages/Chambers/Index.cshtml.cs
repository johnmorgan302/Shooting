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
    public class IndexModel : PageModel
    {
        private readonly ShootingContext _context;

        public IndexModel(ShootingContext context)
        {
            _context = context;
        }

        public IList<Chamber> Chamber { get;set; }

        public async Task OnGetAsync()
        {
            Chamber = await _context.Chamber.ToListAsync();
        }
    }
}
