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

namespace ServiceAuto.Web.Pages.Interventii
{
    public class EditModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public EditModel(ServiceAuto.Web.Data.ServiceAutoContext context)
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

            var interventiepiesa =  await _context.InterventiiPiese.FirstOrDefaultAsync(m => m.InterventieId == id);
            if (interventiepiesa == null)
            {
                return NotFound();
            }
            InterventiePiesa = interventiepiesa;
           ViewData["InterventieId"] = new SelectList(_context.Interventii, "InterventieId", "DescriereProblema");
           ViewData["PiesaDeSchimbId"] = new SelectList(_context.PieseDeSchimb, "PiesaDeSchimbId", "CodProdus");
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

            _context.Attach(InterventiePiesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventiePiesaExists(InterventiePiesa.InterventieId))
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

        private bool InterventiePiesaExists(int id)
        {
            return _context.InterventiiPiese.Any(e => e.InterventieId == id);
        }
    }
}
