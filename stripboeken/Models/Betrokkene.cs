using System.ComponentModel.DataAnnotations;

namespace stripboeken.Models;

public class Betrokkene
{
    public int betId { get; set; }
    
    [Required, MinLength(2), MaxLength(128)]
    public string voornaam { get; set; }

    [Required, MinLength(2), MaxLength(128)]
    public string achternaam { get; set; }
    
    [Required, MinLength(2)]
    public string webLink { get; set; }
}