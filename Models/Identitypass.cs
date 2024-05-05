using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class Identitypass
{
    public int Identpassid { get; set; }

    public string Password { get; set; } = null!;

    public bool Isactive { get; set; }

    public int Userid { get; set; }

    public int Validtill { get; set; }

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual User User { get; set; } = null!;
}
