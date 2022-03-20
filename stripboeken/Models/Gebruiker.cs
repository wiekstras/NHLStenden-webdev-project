namespace stripboeken.Models;

public class Gebruiker
{
    public int GebruikersId { get; set; }

    public string Rol { get; set; }
    
    public string Email { get; set; }
    
    public string GebruikersNaam { get; set; }
    
    public string VolledigeNaam { get; set; }
    
    public int Is18plus { get; set; }

    public string Wachtwoord { get; set; }

    public string Salt { get; set; }
    
}