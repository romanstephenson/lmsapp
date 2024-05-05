using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class Email
{
    public int Emailid { get; set; }

    public int Userid { get; set; }

    public string EmailAddress { get; set; } = null!;

    public byte IsPrimary { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public virtual User User { get; set; } = null!;
}
