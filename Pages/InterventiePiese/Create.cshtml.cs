using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAuto.Web.Pages.InterventiePiese
{
    [Authorize(Roles = "Admin,Mecanic")]

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
                OnGet();
                return Page();
            }

            bool existaDeja = await _context.InterventiiPiese.AnyAsync(ip =>
                ip.InterventieId == InterventiePiesa.InterventieId &&
                ip.PiesaDeSchimbId == InterventiePiesa.PiesaDeSchimbId);

            if (existaDeja)
            {
                ModelState.AddModelError(string.Empty,
                    "Această piesă este deja asociată intervenției. Modificați cantitatea din listă.");
                OnGet();
                return Page();
            }

            _context.InterventiiPiese.Add(InterventiePiesa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
