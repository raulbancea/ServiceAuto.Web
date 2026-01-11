using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceAuto.Web.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ServiceAuto.Web.Pages.Login
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ServiceAutoContext _context;

        public IndexModel(ServiceAutoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Parola { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mecanic = _context.Mecanici
                .FirstOrDefault(m => m.Email == Email && m.ParolaHash == Parola);

            if (mecanic == null)
            {
                ErrorMessage = "Email sau parola incorecte.";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, mecanic.Email),
                new Claim(ClaimTypes.Role, mecanic.Rol),
                new Claim("MecanicId", mecanic.MecanicId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
            );

            return RedirectToPage("/Index");
        }
    }
}
