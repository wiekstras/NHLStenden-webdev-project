using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

public class Comic : PageModel
{
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
}