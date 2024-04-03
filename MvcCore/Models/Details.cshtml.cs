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
    public class DetailsModel : PageModel
    {
        private readonly MvcCore.Data.ApplicationDbContext _context;

        public DetailsModel(MvcCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Dog Dog { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dog == null)
            {
                return NotFound();
            }

            var dog = await _context.Dog.FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }
            else 
            {
                Dog = dog;
            }
            return Page();
        }
    }
}
