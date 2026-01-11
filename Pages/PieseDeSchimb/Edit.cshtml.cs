using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.PieseDeSchimb
{
    public class EditModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public EditModel(ServiceAuto.Web.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PiesaDeSchimb PiesaDeSchimb { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piesadeschimb =  await _context.PieseDeSchimb.FirstOrDefaultAsync(m => m.PiesaDeSchimbId == id);
            if (piesadeschimb == null)
            {
                return NotFound();
            }
            PiesaDeSchimb = piesadeschimb;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PiesaDeSchimb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiesaDeSchimbExists(PiesaDeSchimb.PiesaDeSchimbId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PiesaDeSchimbExists(int id)
        {
            return _context.PieseDeSchimb.Any(e => e.PiesaDeSchimbId == id);
        }
    }
}
