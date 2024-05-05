using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class UserTypeMapping
{
    public int Usertypemappingid { get; set; }

    public int Userid { get; set; }

    public int Usertypeid { get; set; }

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual UserType Usertype { get; set; } = null!;
}
