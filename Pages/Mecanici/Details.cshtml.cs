using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.Mecanici
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public DetailsModel(ServiceAuto.Web.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public Mecanic Mecanic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mecanic = await _context.Mecanici.FirstOrDefaultAsync(m => m.MecanicId == id);

            if (mecanic is not null)
            {
                Mecanic = mecanic;

                return Page();
            }

            return NotFound();
        }
    }
}
