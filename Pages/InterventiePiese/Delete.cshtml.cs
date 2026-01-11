using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.InterventiePiese
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceAutoContext _context;

        public DeleteModel(ServiceAutoContext context)
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
            var entity = await _context.InterventiiPiese.FirstOrDefaultAsync(m =>
                m.InterventieId == InterventiePiesa.InterventieId &&
                m.PiesaDeSchimbId == InterventiePiesa.PiesaDeSchimbId);

            if (entity != null)
            {
                _context.InterventiiPiese.Remove(entity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
