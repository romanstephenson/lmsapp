using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class StudentCategory
{
    public int Catid { get; set; }

    public string Category { get; set; } = null!;

    public int MaxAllowed { get; set; }

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
