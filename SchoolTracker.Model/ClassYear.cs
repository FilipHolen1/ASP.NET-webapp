using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTracker.Model;

public class ClassYear
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(10)]
    public string Name { get; set; }

    public virtual ICollection<Student> Students{ get; set; }
}
