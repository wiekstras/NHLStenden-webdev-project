using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;

namespace stripboeken.Pages
{
    public class Login : PageModel
    {
        [BindProperty]
        public LoginModel LoginModel { get; set; }

        private readonly SignInManager<IdentityUser> signInManager;

        public Login(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(LoginModel.gebruikersNaam, LoginModel.wachtwoord, false,false);
                if (identityResult.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Email en of wachtwoord is fout ");
            }

            return Page();
        }
    }
}