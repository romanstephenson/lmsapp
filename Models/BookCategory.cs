using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class BookCategory
{
    public int Bookcatid { get; set; }

    public string Category { get; set; } = null!;

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
