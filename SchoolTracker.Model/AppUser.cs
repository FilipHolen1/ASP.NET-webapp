using System.ComponentModel.DataAnnotations;

namespace SchoolTracker.Model;

public abstract class AppUser
{
    [Key]
    public int ID { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Lozinka mora imati barem 6 znakova")]
    public string Password { get; set; }
}
