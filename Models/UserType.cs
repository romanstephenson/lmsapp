using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class UserType
{
    public int Usertypeid { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual ICollection<UserTypeMapping> UserTypeMappings { get; set; } = new List<UserTypeMapping>();
}
