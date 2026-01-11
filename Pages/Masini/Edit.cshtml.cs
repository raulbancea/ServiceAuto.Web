using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAuto.Web.Pages.Masini
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ServiceAutoContext _context;

        public EditModel(ServiceAutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masina Masina { get; set; } = default!;

        public SelectList ClientList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Masina = await _context.Masini
                .Include(m => m.Client)
                .FirstOrDefaultAsync(m => m.MasinaId == id);

            if (Masina == null)
                return NotFound();

            ClientList = new SelectList(
                _context.Clients,
                "ClientId",
                "Nume",
                Masina.ClientId
            );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ClientList = new SelectList(
                    _context.Clients,
                    "ClientId",
                    "Nume",
                    Masina.ClientId
                );
                return Page();
            }

            _context.Attach(Masina).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
