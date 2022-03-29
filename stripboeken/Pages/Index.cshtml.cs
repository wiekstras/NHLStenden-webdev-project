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

    [BindProperty]
    public Filter Filter { get; set; }

    public IEnumerable<DetailUitgave> Uitgaves { get; set; }

    public void OnGet()
    {
        Uitgaves = new UitgaveRepository().Get();
    }

    public void OnPost()
    {
        if(Filter.Name == "reeks")
        {
            Uitgaves = new UitgaveRepository().SearchReeks(Filter);
        }
        else if(Filter.Name == "boek")
        {
            Uitgaves = new UitgaveRepository().SearchBoek(Filter);
        }
        else
        {
            Uitgaves = new UitgaveRepository().SearchISBN(Filter);
        }
    }
}