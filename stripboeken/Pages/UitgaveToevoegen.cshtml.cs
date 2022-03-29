using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages
{
    public class UitgaveToevoegen : PageModel
    {
        //TempData voor het onthouden van de reeksId en boekId, wanneer de OnPostReeks wordt gebruikt.
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
        //Lijst van bestaande auteurs voor in de select dropdown.
        public IEnumerable<Auteur> ListAuteurs
        {
            get
            {
                return new AuteurRepository().Get();
            }
        }
        //Lijst van bestaande stripboeken voor in de select dropdown.
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
        //Lijst van bestaande reeksen voor in de select dropdown.
        public IEnumerable<Reeks> Reeksen
        {
            get
            {
                return new ReeksRepository().Get();
            }
        }

        //Deze boolean voorkomt dat een uitgave niet kan worden aangemaakt voordat deze aan een boekId gelinkt is.
        public bool ToggleMenu { get; set; } = false;

        public void OnGet(int reeksid, int boekid)
        {
            //Als reeksid of boekid al meegegeven worden in de query string dan worden ze in de OnGet opgehaald.
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

        public void OnPostReeks()
        {
            //Als de reeks niet bestaat dan wordt er een titel meegegeven door de gebruiker.
            //Reeks wordt toegekend aan een nieuwe reeks vanuit de database met uniek Id.
            if (Reeks.Titel != null)
            {
                Reeks = new ReeksRepository().Add(Reeks.Titel);
            }
            //Als de gebruiker kiest voor een bestaande reeks. Dan wordt deze uit de database gehaald met het bijbehorende reeksId.
            else
            {
                Reeks = new ReeksRepository().GetSingle(Reeks.ReeksId);
            }
            //In beide gevallen wordt de reeksId opgeslagen voor de volgende OnPost.
            TempData["NewReeksId"] = Reeks.ReeksId.ToString();
        }

        public void OnPostBoek()
        {
            //Een nieuw boek wordt aangemaakt met de titel die de gebruiker heeft aangegeven.
            //Het reeksId wordt omgezet vanuit de TempData naar een integer.
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

            //Door ToggleMenu op true te zetten, verbergt het huidige menu en wordt het aanmaken van de uitgave weergeven.
            ToggleMenu = true;
        }

        public IActionResult OnPostUitgave()
        {
            //todo: ModelState Validatie

            Uitgave.BoekId = Convert.ToInt32(NewBoekId);

            Uitgave = new UitgaveRepository().Add(Uitgave);

            //Als de gebruiker een bestaande auteur en illustrator kiest dan worden de volgende controles uitgevoerd.
            //Als de auteur en illustrator hetzelfde zijn dan krijgt deze de functie beide toegewezen voor desbetreffende uitgave.
            //Als dit niet het geval is dan worden er aparte functies toegewezen.
            if (Auteur.AuteurId == Illustrator.AuteurId && Auteur.AuteurId != 0)
            {
                Auteur.UitgaveId = Uitgave.UitgaveId;
                Auteur.Functie = "Beide";
                new AuteurRepository().Add(Auteur);
            }
            else
            {
                if (Auteur.AuteurId != 0)
                {
                    Auteur.UitgaveId = Uitgave.UitgaveId;
                    Auteur.Functie = "Auteur";
                    new AuteurRepository().Add(Auteur);
                }

                if (Illustrator.AuteurId != 0)
                {
                    Illustrator.UitgaveId = Uitgave.UitgaveId;
                    Illustrator.Functie = "Illustrator";
                    new AuteurRepository().Add(Illustrator);
                }
            }

            //Als de auteur of illustrator niet bestaat dan worden ze aangemaakt in de database en vervolgens gekoppeld aan de uitgave.
            if (NewAuteur.Voornaam == NewIllustrator.Voornaam && NewAuteur.Voornaam != null)
            {
                NewAuteur = new AuteurRepository().AddAuteur(NewAuteur);

                Auteur.AuteurId = NewAuteur.AuteurId;
                Auteur.UitgaveId = Uitgave.UitgaveId;
                Auteur.Functie = "Beide";

                new AuteurRepository().Add(Auteur);
            }

            else
            {
                if (NewAuteur.Voornaam != null)
                {
                    NewAuteur = new AuteurRepository().AddAuteur(NewAuteur);

                    Auteur.AuteurId = NewAuteur.AuteurId;
                    Auteur.UitgaveId = Uitgave.UitgaveId;
                    Auteur.Functie = "Auteur";

                    new AuteurRepository().Add(Auteur);
                }

                if (NewIllustrator.Voornaam != null)
                {
                    NewIllustrator = new AuteurRepository().AddAuteur(NewIllustrator);

                    Illustrator.AuteurId = NewIllustrator.AuteurId;
                    Illustrator.UitgaveId = Uitgave.UitgaveId;
                    Illustrator.Functie = "Illustrator";

                    new AuteurRepository().Add(Illustrator);
                }
            }

            return Redirect("/UitgaveToevoegen");
        }
    }
}