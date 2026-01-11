using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.Interventii
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public DetailsModel(ServiceAuto.Web.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public Interventie Interventie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interventie = await _context.Interventii.FirstOrDefaultAsync(m => m.InterventieId == id);

            if (interventie is not null)
            {
                Interventie = interventie;

                return Page();
            }

            return NotFound();
        }
    }
}
