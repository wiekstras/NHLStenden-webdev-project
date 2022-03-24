using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

public class MyCollection : PageModel
{
    private readonly UserManager<IdentityUser> userManager;

    public MyCollection(UserManager<IdentityUser> userManager)
    {
        this.userManager = userManager;
    }
    public IEnumerable<Bezit> Bezit
    {
        //De lijst van producten wordt via een query opgehaald als deze onder de juiste category vallen.
        get
        {
            return new BezitRepository().Get(userManager.GetUserId(User));
        }
    }
    public void OnGet()
    {
        
    }
}