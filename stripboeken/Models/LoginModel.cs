using System.ComponentModel.DataAnnotations;

namespace stripboeken.Models;

public class LoginModel
{
    
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Gebruikersnaam")]
    public string gebruikersNaam { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Wachtwoord")]
    public string wachtwoord { get; set; }

}