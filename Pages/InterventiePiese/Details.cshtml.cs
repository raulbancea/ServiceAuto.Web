using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.InterventiePiese
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceAutoContext _context;

        public DetailsModel(ServiceAutoContext context)
        {
            _context = context;
        }

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
    }
}
