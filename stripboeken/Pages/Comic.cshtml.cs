using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

public class Comic : PageModel
{
    
    private readonly UserManager<IdentityUser> userManager;

    public Comic(UserManager<IdentityUser> userManager)
    {
        this.userManager = userManager;
    }    
    [BindProperty(SupportsGet = true)]
    public int UitgaveId { get; set; }
    public DetailUitgave Uitgave
    {
        get
        {
            return new UitgaveRepository().Get(UitgaveId);
        }
    }

    public IEnumerable<Uitgave> Uitgaves
    {
        get
        {
            return new UitgaveRepository().GetThree(UitgaveId, Uitgave.ReeksId);
        }
    }
    
    public IEnumerable<Auteur> Auteurs
    {
        get
        {
            return new AuteurRepository().Get(UitgaveId);
        }
    }

    public void OnGet()
    {
    }

    public IActionResult OnPostAddToCollection()
    {
        new BezitRepository().AddToCollection(userManager.GetUserId(User), UitgaveId, Uitgave.AfbeeldingsPad);
        return RedirectToPage("MyCollection");
    }
}