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
    }

    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        new UitgaveRepository().Update(uitgaveId);
    }
}