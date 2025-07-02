using System.ComponentModel.DataAnnotations;

namespace SchoolTracker.Models.ViewModels;

public class LoginViewModel
{
    [Required]
    [EmailAddress(ErrorMessage = "Unesite ispravnu email adresu")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
