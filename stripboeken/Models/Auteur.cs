namespace stripboeken.Models;

public class Auteur
{
    public int auteurId { get; set; }
    
    public string voornaam { get; set; }
    
    public string achternaam { get; set; }
    
    public string weblink { get; set; }

    public enum functie
    {
        Schrijver,
        Illustrator,
        Beide,
    }
}