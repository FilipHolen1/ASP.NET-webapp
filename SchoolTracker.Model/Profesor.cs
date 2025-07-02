using System.ComponentModel.DataAnnotations;

namespace SchoolTracker.Model;

public class Profesor 
{
    [Key]
    public int ID { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Unesite barem 3 znaka")]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Unesite barem 3 znaka")]
    [StringLength(50)]
    public string LastName { get; set; }
    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Unesite ispravnu email adresu (npr. mail@example.com)")]
    public string Email { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();


    public string FullName => $"{FirstName} {LastName}";

  
}
