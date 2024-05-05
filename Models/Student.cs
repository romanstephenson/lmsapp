using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class Student
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Catid { get; set; }

    public int Facultyid { get; set; }

    public int Year { get; set; }

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual StudentCategory Cat { get; set; } = null!;

    public virtual Faculty Faculty { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
