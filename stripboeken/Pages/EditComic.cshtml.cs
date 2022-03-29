using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

public class EditComic : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int UitgaveId { get; set; }

    //Haalt de bestaande gegevens op van de uitgave.
    public DetailUitgave Uitgave
    {
        get
        {
            return new UitgaveRepository().Get(UitgaveId);
        }
    }

    [BindProperty]
    public Uitgave EditUitgave { get; set; }

    [BindProperty]
    public Boek EditBoek { get; set; }

    public IActionResult OnPost()
    {
        EditUitgave.BoekId = EditBoek.BoekId;
        new BoekRepository().Update(EditBoek);
        new UitgaveRepository().Update(EditUitgave);

        return Redirect("Comic?uitgaveId=" + UitgaveId);
    }
}