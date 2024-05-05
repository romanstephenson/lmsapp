using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class Faculty
{
    public int Facultyid { get; set; }

    public string Facultyname { get; set; } = null!;

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
