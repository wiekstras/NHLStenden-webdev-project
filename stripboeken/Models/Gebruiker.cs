namespace stripboeken.Models;

public class Gebruiker
{
    public int gebruikersId { get; set; }

    public enum rol
    {
        Standaard,
        Beheerder
    }
    
    public string email { get; set; }
    
    public string gebruikersNaam { get; set; }
    
    public string volledigeNaam { get; set; }
    
    public int is18plus { get; set; }

    public string wachtwoord { get; set; }

    public string salt { get; set; }
    
}