namespace stripboeken.Models;

public class Gebruiker
{
    public int gebruikersId { get; set; }
    
    public int rol { get; set; }
    
    public string email { get; set; }
    
    public string gebruikersnaam { get; set; }
    
    public string volledigeNaam { get; set; }
    
    public bool nsfw { get; set; }
    
    public string salt { get; set; }
    
    public string wachtwoord { get; set; }
    
}