using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class Verification
{
    public int Verid { get; set; }

    public byte Verificationstatus { get; set; }

    public string Verificationtoken { get; set; } = null!;

    public int Userid { get; set; }

    public DateTime CreatedDt { get; set; }

    public DateTime VerifiedDt { get; set; }

    public virtual User User { get; set; } = null!;
}
