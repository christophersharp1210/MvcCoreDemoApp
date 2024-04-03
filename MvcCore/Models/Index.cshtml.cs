using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcCore.Data;

namespace MvcCore.Models
{
    public class IndexModel : PageModel
    {
        private readonly MvcCore.Data.ApplicationDbContext _context;

        public IndexModel(MvcCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Dog != null)
            {
                Dog = await _context.Dog.ToListAsync();
            }
        }
    }
}
