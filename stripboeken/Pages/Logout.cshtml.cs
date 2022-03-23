using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace stripboeken.Pages;

public class Logout : PageModel
{
    private readonly SignInManager<IdentityUser> signInManager;

    public Logout(SignInManager<IdentityUser> signInManager)
    {
        this.signInManager = signInManager;
    }
    
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostLogoutAsync()
    {
        await signInManager.SignOutAsync();
        return RedirectToPage("Login");
    }
    
    public IActionResult OnPostDontLogoutAsync()
    {
        return RedirectToPage("Index");
    }
}