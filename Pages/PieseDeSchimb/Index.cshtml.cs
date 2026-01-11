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
    public class IndexModel : PageModel
    {
        private readonly ServiceAuto.Web.Data.ServiceAutoContext _context;

        public IndexModel(ServiceAuto.Web.Data.ServiceAutoContext context)
        {
            _context = context;
        }

        public IList<PiesaDeSchimb> PiesaDeSchimb { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PiesaDeSchimb = await _context.PieseDeSchimb.ToListAsync();
        }
    }
}
