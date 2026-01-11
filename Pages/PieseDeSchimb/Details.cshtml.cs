using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceAuto.Web.Data;
using ServiceAuto.Web.Models;

namespace ServiceAuto.Web.Pages.PieseDeSchimb
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public DetailsModel(ServiceAuto.Web.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public PiesaDeSchimb PiesaDeSchimb { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piesadeschimb = await _context.PieseDeSchimb.FirstOrDefaultAsync(m => m.PiesaDeSchimbId == id);

            if (piesadeschimb is not null)
            {
                PiesaDeSchimb = piesadeschimb;

                return Page();
            }

            return NotFound();
        }
    }
}
