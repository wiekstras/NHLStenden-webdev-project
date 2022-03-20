using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

public class Comic : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int UitgaveId { get; set; }
    public Uitgave Uitgave
    {
        get
        {
            return new UitgaveRepository().Get(UitgaveId);
        }
    }

    public Boek Boek
    {
        get
        {
            return new BoekRepository().Get(Uitgave.BoekId);
        }
    }

    public Reeks Reeks
    {
        get
        {
            return new ReeksRepository().Get(Boek.ReeksId);
        }
    }

    public IEnumerable<Uitgave> Uitgaves
    {
        get
        {
            return new UitgaveRepository().GetThree(UitgaveId, Boek.ReeksId);
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
}