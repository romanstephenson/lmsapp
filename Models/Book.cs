using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class Book
{
    public int Bookid { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public DateTime? Yearpublished { get; set; }

    public long Availablecopies { get; set; }

    public int Bookcatid { get; set; }

    public int Userid { get; set; }

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual ICollection<BookIssueLog> BookIssueLogs { get; set; } = new List<BookIssueLog>();

    public virtual BookCategory Bookcat { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
