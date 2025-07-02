using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchoolTracker.Model;

public class Subject
{
    public int ID { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }


    [ForeignKey(nameof(Profesor))]
    public int ProfesorID { get; set; }
    public virtual Profesor Profesor { get; set; }

    // N:N sa studentima
    public virtual ICollection<Grade> Grades { get; set; }
}
