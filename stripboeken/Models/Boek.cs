using System.ComponentModel.DataAnnotations;

namespace stripboeken.Models;

public class Boek
{
    public int BoekId { get; set; }
    
    [Required]
    public string Titel { get; set; }
    
    public string WebLink { get; set; }
    
    public bool Is18Plus { get; set; }
    
    public int ReeksId { get; set; }

}