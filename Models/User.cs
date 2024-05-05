using System;
using System.Collections.Generic;

namespace lmsapp.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Middlename { get; set; }

    public string Lastname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Gender { get; set; } = null!;

    public int ChangePass { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDt { get; set; }

    public DateTime ModifiedDt { get; set; }

    public virtual ICollection<BookIssueLog> BookIssueLogIssuedByNavigations { get; set; } = new List<BookIssueLog>();

    public virtual ICollection<BookIssueLog> BookIssueLogIssuedToNavigations { get; set; } = new List<BookIssueLog>();

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

    public virtual ICollection<Identitypass> Identitypasses { get; set; } = new List<Identitypass>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<UserTypeMapping> UserTypeMappings { get; set; } = new List<UserTypeMapping>();

    public virtual ICollection<Verification> Verifications { get; set; } = new List<Verification>();
}
