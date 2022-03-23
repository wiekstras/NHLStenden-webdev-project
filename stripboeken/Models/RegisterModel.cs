using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace stripboeken.Models;

public class RegisterModel : IdentityUser
{
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Gebruiksersnaam")]
    public string gebruikersNaam { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Volledige naam")]
    public string voledigeNaam { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email adres")]
    public string email { get; set; }
    
    public string is18plus { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Wachtwoord")]
    public string wachtwoord { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(wachtwoord), ErrorMessage = "Ingevoerde wachtworden komen niet overeen")]
    [Display(Name = "Confirm wachtwoord")]
    public string confirmWachtwoord { get; set; }
    
}