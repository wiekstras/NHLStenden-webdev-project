using System.ComponentModel.DataAnnotations;

namespace stripboeken.Models;

public class Boek
{
    public int BoekId { get; set; }
    
    [Required]
    public string Titel { get; set; }
    
    [Display(Name = "Weblink")]

    public string WebLink { get; set; }
    
    [Display(Name = "Is 18 plus")]

    public bool Is18Plus { get; set; }
    
    public int ReeksId { get; set; }

}