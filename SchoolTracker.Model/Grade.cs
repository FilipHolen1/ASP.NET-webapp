using SchoolTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolTracker.Model;

public class Grade
{
    public int StudentID { get; set; }
    public int SubjectID { get; set; }

    [Range(1, 5)]
    public int Value { get; set; }

    public virtual Student Student { get; set; }
    public virtual Subject Subject { get; set; }
}
