namespace stripboeken.Models
{
    public class DetailAuteur
    {
        public int AuteurId { get; set; }
        public int UitgaveId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }  
        public string Functie { get; set; }
        public string Weblink { get; set; }

    }
}
