using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.InterventiePiese
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public DetailsModel(ServiceAuto.Web.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public InterventiePiesa InterventiePiesa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interventiepiesa = await _context.InterventiiPiese.FirstOrDefaultAsync(m => m.InterventieId == id);

            if (interventiepiesa is not null)
            {
                InterventiePiesa = interventiepiesa;

                return Page();
            }

            return NotFound();
        }
    }
}
