using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.Interventii
{
    public class CreateModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public CreateModel(ServiceAuto.Web.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InterventieId"] = new SelectList(_context.Interventii, "InterventieId", "DescriereProblema");
        ViewData["PiesaDeSchimbId"] = new SelectList(_context.PieseDeSchimb, "PiesaDeSchimbId", "CodProdus");
            return Page();
        }

        [BindProperty]
        public InterventiePiesa InterventiePiesa { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InterventiiPiese.Add(InterventiePiesa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
