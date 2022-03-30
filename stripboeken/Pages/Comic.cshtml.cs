<<<<<<< HEAD
using System.Collections.Generic;
=======
using Microsoft.AspNetCore.Identity;
>>>>>>> 1bacf5ee0d69010099fbd5a6507a5b49e5fe43e8
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
    
    public IEnumerable<DetailAuteur> Auteurs
    {
        get
        {
            return new AuteurRepository().GetFromUitgave(UitgaveId);
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