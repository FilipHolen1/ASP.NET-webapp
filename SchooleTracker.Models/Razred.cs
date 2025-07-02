using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchooleTracker.Models
{
    public class Razred
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Naziv { get; set; }

        // Navigacija: razred ima više učenika
        public virtual ICollection<Student> Studenti { get; set; }
    }

}
