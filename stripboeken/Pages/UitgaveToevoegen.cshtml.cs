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
        [TempData]
        public string NewBoekId { get; set; }
        [BindProperty]
        public Reeks Reeks { get; set; } = null;
        [BindProperty]
        public Boek Boek { get; set; } = null;
        [BindProperty]
        public Uitgave Uitgave { get; set; }

        [BindProperty]
        public Schrijft Auteur { get; set; }
        [BindProperty]
        public Schrijft Illustrator { get; set; }

        [BindProperty]
        public Auteur NewAuteur { get; set; } 

        [BindProperty]
        public Auteur NewIllustrator { get; set; }
        public IEnumerable<Auteur> ListAuteurs
        {
            get
            {
                return new AuteurRepository().Get();
            }
        }

        public IEnumerable<Boek> Boeken
        {
            get
            {
                if (Reeks != null)
                {
                    return new BoekRepository().Get(Reeks.ReeksId);
                }
                return null;
            }
        }
        public IEnumerable<Reeks> Reeksen
        {
            get
            {
                return new ReeksRepository().Get();
            }
        }

        public void OnGet(int reeksid, int boekid)
        {
            if (reeksid != 0)
            {
                Reeks = new ReeksRepository().GetSingle(reeksid);
            }

            if (boekid != 0)
            {
                Boek = new BoekRepository().GetSingle(boekid);
                TempData["NewBoekId"] = Boek.BoekId.ToString();
                ToggleMenu = true;
            }
        }

        public bool ToggleMenu { get; set; } = false;

        public void OnPostReeks()
        {
            if (Reeks.Titel != null)
            {
                Reeks = new ReeksRepository().Add(Reeks.Titel);
            }
            else
            {
                Reeks = new ReeksRepository().GetSingle(Reeks.ReeksId);
            }

            TempData["NewReeksId"] = Reeks.ReeksId.ToString();
        }

        public void OnPostBoek()
        {
            if (Boek.Titel != null)
            {
                Boek.ReeksId = Convert.ToInt32(NewReeksId);
                Boek = new BoekRepository().Add(Boek);
            }
            else
            {
                Boek = new BoekRepository().GetSingle(Boek.BoekId);
            }

            TempData["NewBoekId"] = Boek.BoekId.ToString();
            ToggleMenu = true;
        }

        public IActionResult OnPostUitgave()
        {
            Uitgave.BoekId = Convert.ToInt32(NewBoekId);

            Uitgave = new UitgaveRepository().Add(Uitgave);

            if (Auteur.AuteurId != 0)
            {
                Auteur.Functie = "Auteur";
                Illustrator.Functie = "Illustrator";

                Auteur.UitgaveId = Uitgave.UitgaveId;
                Illustrator.UitgaveId = Uitgave.UitgaveId;

                if (Auteur.AuteurId == Illustrator.AuteurId)
                {
                    Auteur.Functie = "Beide";
                    new AuteurRepository().Add(Auteur);
                }
                else
                {
                    new AuteurRepository().Add(Auteur);
                    new AuteurRepository().Add(Illustrator);
                }
            }

            return Redirect("/UitgaveToevoegen");
        }
    }
}