using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Uitgave> Uitgaves
    {
        //De lijst van producten wordt via een query opgehaald als deze onder de juiste category vallen.
        get
        {
            return new UitgaveRepository().Get();
        }
    }

    public void OnGet()
    {
    }
}