using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class Staff
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string Department { get; set; } = null!;

    public DateTime HireStartDt { get; set; }

    public DateTime HireEndDt { get; set; }

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual User User { get; set; } = null!;
}
