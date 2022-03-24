using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages
{
    public class UitgaveToevoegen : PageModel
    {
        [TempData]
        public string NewReeksId { get; set; }
        [BindProperty]
        public Reeks Reeks  { get; set; } = null;
        [BindProperty]
        public Boek Boek { get; set; }
        [BindProperty]
        public Uitgave Uitgave { get; set; }
        [BindProperty]
        public Auteur Auteur { get; set; }
        public IEnumerable<Auteur> Auteurs { get; set; }

        public IEnumerable<Boek> Boeken
        {
            get
            {
                if (Reeks != null) {
                    return new BoekRepository().Get(Reeks.ReeksId);
                }
                return null;
            }
        }
        public IEnumerable<Reeks> Reeksen { 
            get
            {
                return new ReeksRepository().Get();
            }
        }

        public void OnGet(int reeksid)
        {
            if(reeksid != 0)
            {
                Reeks = new ReeksRepository().Get(reeksid);
            }
        }

        public void OnPostReeks()
        {
            if(Reeks.Titel != null)
            {
                Reeks = new ReeksRepository().Add(Reeks.Titel);
            }
            else
            {
                Reeks = new ReeksRepository().Get(Reeks.ReeksId);
            }

            TempData["NewReeksId"] = Reeks.ReeksId.ToString();
        }

        public IActionResult OnPostUitgave()
        {
            if (Boek.Titel != null)
            {
                Boek.ReeksId = Convert.ToInt32(NewReeksId);
                Boek = new BoekRepository().Add(Boek);
            }

            Uitgave.BoekId = Boek.BoekId;
            new UitgaveRepository().Add(Uitgave);

            return Redirect("/UitgaveToevoegen");
        }
    }
}