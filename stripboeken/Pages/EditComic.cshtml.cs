using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

public class EditComic : PageModel
{
    [BindProperty (SupportsGet = true)]
    public int uitgaveId { get; set; }
    
    public DetailUitgave DetailUitgave { get; set; }
    
    
    public DetailUitgave DetailUitgaveInfo
    {
        get
        {
            return new UitgaveRepository().Get(uitgaveId);
        }
        set
        {
            
        }
    }

    public void OnGet()
    {
        
    }

    public void OnPost(DetailUitgave DetailUitgave)
    {
        Boek boekInfo = new Boek();
        Uitgave uitgaveInfo = new Uitgave();
        boekInfo.Titel = "test";
        DetailUitgave.boekId = DetailUitgaveInfo.boekId;
        DetailUitgave.UitgaveId = uitgaveId;
        boekInfo.Titel = DetailUitgave.BoekTitel;
        boekInfo.WebLink = DetailUitgave.Weblink;
        uitgaveInfo.ISBN = DetailUitgave.ISBN;
        uitgaveInfo.AfbeeldingsPad = DetailUitgave.AfbeeldingsPad;
        uitgaveInfo.Jaar = DetailUitgave.Jaar;
        uitgaveInfo.Uitgever = DetailUitgave.Uitgever;
        uitgaveInfo.Druk = DetailUitgave.Druk;
        uitgaveInfo.Cover = DetailUitgave.Cover;
        uitgaveInfo.Taal = DetailUitgave.Taal;
        uitgaveInfo.AantalBladzijden = DetailUitgave.AantalBladzijden;
        uitgaveInfo.Breedte = DetailUitgave.Breedte;
        uitgaveInfo.Hoogte = DetailUitgave.Hoogte;
        uitgaveInfo.Beschrijving = DetailUitgave.Beschrijving;
        uitgaveInfo.Weetjes = DetailUitgave.Weetjes;


        new UitgaveRepository().Update(uitgaveInfo, boekInfo);
    }
}