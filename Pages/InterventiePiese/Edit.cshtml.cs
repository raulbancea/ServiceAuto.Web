using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.InterventiePiese
{
    [Authorize(Roles = "Admin,Mecanic")]

    public class EditModel : PageModel
    {
        private readonly ServiceAutoContext _context;

        public EditModel(ServiceAutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InterventiePiesa InterventiePiesa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int interventieId, int piesaDeSchimbId)
        {
            InterventiePiesa = await _context.InterventiiPiese
                .FirstOrDefaultAsync(m =>
                    m.InterventieId == interventieId &&
                    m.PiesaDeSchimbId == piesaDeSchimbId);

            if (InterventiePiesa == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InterventiePiesa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
