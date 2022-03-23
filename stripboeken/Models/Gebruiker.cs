using System.ComponentModel.DataAnnotations;

namespace stripboeken.Models;

public class Gebruiker
{
    public int GebruikersId { get; set; }

    public string Rol { get; set; }
    
  
    public string gebruikersNaam { get; set; }

   
    public string voledigeNaam { get; set; }

    public string email { get; set; }
    
    public string is18plus { get; set; }
    
    public string wachtwoord { get; set; }
    
    
    public int Is18plus { get; set; }

    
}