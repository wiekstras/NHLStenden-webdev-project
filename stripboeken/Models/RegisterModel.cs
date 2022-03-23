using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace stripboeken.Models;

public class RegisterModel : IdentityUser
{
    [Required]
    [DataType(DataType.Text)]
    public string gebruikersNaam { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string voledigeNaam { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string email { get; set; }
    
    public string is18plus { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string wachtwoord { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(wachtwoord), ErrorMessage = "Ingevoerde wachtworden komen niet overeen")]
    public string confirmWachtwoord { get; set; }
    
}