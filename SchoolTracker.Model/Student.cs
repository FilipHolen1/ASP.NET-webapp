using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTracker.Model;

public class Student
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

    [Column(TypeName = "date")]
    public DateTime? DateOfBirth { get; set; }
    [Required]
    [ForeignKey(nameof(ClassYear))]
    public int ClassYearID { get; set; }

    public ClassYear? ClassYear { get; set; }


    public virtual ICollection<Grade> Grades { get; set; }

    public string FullName => $"{FirstName} {LastName}";
    public Student()
    {
        Grades = new List<Grade>(); 
    }

}

