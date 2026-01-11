using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.Masini
{
    public class CreateModel : PageModel
    {
        private readonly ServiceAutoContext _context;

        public CreateModel(ServiceAutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masina Masina { get; set; } = default!;

        public SelectList ClientList { get; set; } = default!;

        public void OnGet()
        {
            ClientList = new SelectList(_context.Clients, "ClientId", "Nume");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // IMPORTANT: daca e invalid, trebuie sa reincarci lista din nou
            if (!ModelState.IsValid)
            {
                ClientList = new SelectList(_context.Clients, "ClientId", "Nume");
                return Page();
            }

            _context.Masini.Add(Masina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
