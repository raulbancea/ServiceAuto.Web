using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace ServiceAuto.Web.Pages.PieseDeSchimb
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public CreateModel(ServiceAuto.Web.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PiesaDeSchimb PiesaDeSchimb { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PieseDeSchimb.Add(PiesaDeSchimb);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
