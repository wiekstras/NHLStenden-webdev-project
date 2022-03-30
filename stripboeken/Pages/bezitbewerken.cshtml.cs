using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

public class bezitbewerken : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int bezitId { get; set; }
    
    [BindProperty]
    public Bezit EditBezit { get; set; }
    
    public Bezit Bezit
    {
        get
        {
            return new BezitRepository().GetFromBezitId(bezitId);
        }
    }
    
    public void OnGet()
    {
        
    }
    public IActionResult OnPost()
    {
        EditBezit.BezitId = bezitId;
        new BezitRepository().Update(EditBezit);
        return Redirect("MyCollection");
    }
}