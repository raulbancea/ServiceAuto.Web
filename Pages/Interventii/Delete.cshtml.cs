using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.Interventii
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public DeleteModel(ServiceAuto.Web.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InterventiePiesa InterventiePiesa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interventiepiesa = await _context.InterventiiPiese.FirstOrDefaultAsync(m => m.InterventieId == id);

            if (interventiepiesa is not null)
            {
                InterventiePiesa = interventiepiesa;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interventiepiesa = await _context.InterventiiPiese.FindAsync(id);
            if (interventiepiesa != null)
            {
                InterventiePiesa = interventiepiesa;
                _context.InterventiiPiese.Remove(InterventiePiesa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
