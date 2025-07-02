using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchooleTracker.Models
{
    public class Predmet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }

        // FK na profesora
        public int ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }

        // Navigacija za N:N sa studentima
        public virtual ICollection<StudentPredmet> StudentPredmeti { get; set; }
    }

}
