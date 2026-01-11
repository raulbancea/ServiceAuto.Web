using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.Masini
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceAutoContext _context;

        public DeleteModel(ServiceAutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masina Masina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Masina = await _context.Masini
                .Include(m => m.Client)
                .FirstOrDefaultAsync(m => m.MasinaId == id);

            if (Masina == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var masina = await _context.Masini.FindAsync(id);

            if (masina != null)
            {
                _context.Masini.Remove(masina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
