using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class BookIssueLog
{
    public int Bookissueid { get; set; }

    public int IdOfBook { get; set; }

    public int IssuedTo { get; set; }

    public int IssuedBy { get; set; }

    public DateTime IssueDt { get; set; }

    public DateTime ReturnDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual Book IdOfBookNavigation { get; set; } = null!;

    public virtual User IssuedByNavigation { get; set; } = null!;

    public virtual User IssuedToNavigation { get; set; } = null!;
}
