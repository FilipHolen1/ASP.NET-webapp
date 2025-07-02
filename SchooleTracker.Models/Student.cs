using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
public class Student
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Ime { get; set; }

    [Required]
    [StringLength(50)]
    public string Prezime { get; set; }

    public DateTime? DatumRodjenja { get; set; }

    public int RazredId { get; set; }
    public virtual Razred Razred { get; set; }

    public virtual ICollection<StudentPredmet> StudentPredmeti { get; set; }
}


namespace SchooleTracker.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        public DateTime? DatumRodjenja { get; set; }

        public int RazredId { get; set; }
        public virtual Razred Razred { get; set; }

        public virtual ICollection<StudentPredmet> StudentPredmeti { get; set; }
    }


}
