using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lmsapp.Models;

public partial class LmsContext : DbContext
{
    public LmsContext()
    {
    }

    public LmsContext(DbContextOptions<LmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<BookIssueLog> BookIssueLogs { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Identitypass> Identitypasses { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCategory> StudentCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<UserTypeMapping> UserTypeMappings { get; set; }

    public virtual DbSet<Verification> Verifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:LMSDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Bookid).HasName("PK__BOOK__6E1C5AE3AAC5F866");

            entity.ToTable("BOOK");

            entity.Property(e => e.Bookid).HasColumnName("BOOKID");
            entity.Property(e => e.Author)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("AUTHOR");
            entity.Property(e => e.Availablecopies).HasColumnName("AVAILABLECOPIES");
            entity.Property(e => e.Bookcatid).HasColumnName("BOOKCATID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Isbn)
                .HasColumnType("text")
                .HasColumnName("ISBN");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
            entity.Property(e => e.Publisher)
                .HasColumnType("text")
                .HasColumnName("PUBLISHER");
            entity.Property(e => e.Title)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("TITLE");
            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.Yearpublished)
                .HasColumnType("datetime")
                .HasColumnName("YEARPUBLISHED");

            entity.HasOne(d => d.Bookcat).WithMany(p => p.Books)
                .HasForeignKey(d => d.Bookcatid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOK__BOOKCATID__5AB9788F");

            entity.HasOne(d => d.User).WithMany(p => p.Books)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOK__USERID__5BAD9CC8");
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(e => e.Bookcatid).HasName("PK__BOOK_CAT__32698FA0A56A3A30");

            entity.ToTable("BOOK_CATEGORY");

            entity.Property(e => e.Bookcatid).HasColumnName("BOOKCATID");
            entity.Property(e => e.Category)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("CATEGORY");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
        });

        modelBuilder.Entity<BookIssueLog>(entity =>
        {
            entity.HasKey(e => e.Bookissueid).HasName("PK__BOOK_ISS__902B840E8052AAF2");

            entity.ToTable("BOOK_ISSUE_LOG");

            entity.Property(e => e.Bookissueid).HasColumnName("BOOKISSUEID");
            entity.Property(e => e.IdOfBook).HasColumnName("ID_OF_BOOK");
            entity.Property(e => e.IssueDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ISSUE_DT");
            entity.Property(e => e.IssuedBy).HasColumnName("ISSUED_BY");
            entity.Property(e => e.IssuedTo).HasColumnName("ISSUED_TO");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
            entity.Property(e => e.ReturnDt)
                .HasColumnType("datetime")
                .HasColumnName("RETURN_DT");

            entity.HasOne(d => d.IdOfBookNavigation).WithMany(p => p.BookIssueLogs)
                .HasForeignKey(d => d.IdOfBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOK_ISSU__ID_OF__607251E5");

            entity.HasOne(d => d.IssuedByNavigation).WithMany(p => p.BookIssueLogIssuedByNavigations)
                .HasForeignKey(d => d.IssuedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOK_ISSU__ISSUE__625A9A57");

            entity.HasOne(d => d.IssuedToNavigation).WithMany(p => p.BookIssueLogIssuedToNavigations)
                .HasForeignKey(d => d.IssuedTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOK_ISSU__ISSUE__6166761E");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.Emailid).HasName("PK__EMAIL__B916E1C6E18893EA");

            entity.ToTable("EMAIL");

            entity.Property(e => e.Emailid).HasColumnName("EMAILID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("EMAIL_ADDRESS");
            entity.Property(e => e.IsPrimary).HasColumnName("IS_PRIMARY");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Emails)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EMAIL__USERID__76969D2E");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Facultyid).HasName("PK__FACULTY__754F1CF8AF67B2D2");

            entity.ToTable("FACULTY");

            entity.Property(e => e.Facultyid).HasColumnName("FACULTYID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Facultyname)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("FACULTYNAME");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
        });

        modelBuilder.Entity<Identitypass>(entity =>
        {
            entity.HasKey(e => e.Identpassid).HasName("PK__IDENTITY__F40B38070015FF14");

            entity.ToTable("IDENTITYPASS");

            entity.Property(e => e.Identpassid).HasColumnName("IDENTPASSID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("ISACTIVE");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.Validtill)
                .HasDefaultValue(240)
                .HasColumnName("VALIDTILL");

            entity.HasOne(d => d.User).WithMany(p => p.Identitypasses)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IDENTITYP__USERI__74794A92");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STAFF__3214EC2788B40E14");

            entity.ToTable("STAFF");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Department)
                .HasMaxLength(4000)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.HireEndDt)
                .HasColumnType("datetime")
                .HasColumnName("HIRE_END_DT");
            entity.Property(e => e.HireStartDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("HIRE_START_DT");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STAFF__USERID__41EDCAC5");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STUDENT__3214EC279BD41028");

            entity.ToTable("STUDENT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Catid).HasColumnName("CATID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Facultyid).HasColumnName("FACULTYID");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.Year).HasColumnName("YEAR");

            entity.HasOne(d => d.Cat).WithMany(p => p.Students)
                .HasForeignKey(d => d.Catid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STUDENT__CATID__31B762FC");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Students)
                .HasForeignKey(d => d.Facultyid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STUDENT__FACULTY__32AB8735");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STUDENT__USERID__30C33EC3");
        });

        modelBuilder.Entity<StudentCategory>(entity =>
        {
            entity.HasKey(e => e.Catid).HasName("PK__STUDENT___709E29DBFF2C2345");

            entity.ToTable("STUDENT_CATEGORY");

            entity.Property(e => e.Catid).HasColumnName("CATID");
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CATEGORY");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.MaxAllowed).HasColumnName("MAX_ALLOWED");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__USERS__7B9E7F3550471337");

            entity.ToTable("USERS");

            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.ChangePass).HasColumnName("CHANGE_PASS");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Firstname)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Lastname)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Middlename)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("MIDDLENAME");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
            entity.Property(e => e.Username)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Usertypeid).HasName("PK__USER_TYP__A23D007333E17BDE");

            entity.ToTable("USER_TYPE");

            entity.Property(e => e.Usertypeid).HasColumnName("USERTYPEID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.Status).HasColumnName("STATUS");
        });

        modelBuilder.Entity<UserTypeMapping>(entity =>
        {
            entity.HasKey(e => e.Usertypemappingid).HasName("PK__USER_TYP__538EC9E11F525F0D");

            entity.ToTable("USER_TYPE_MAPPING");

            entity.Property(e => e.Usertypemappingid).HasColumnName("USERTYPEMAPPINGID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.ModifiedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DT");
            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.Usertypeid).HasColumnName("USERTYPEID");

            entity.HasOne(d => d.User).WithMany(p => p.UserTypeMappings)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USER_TYPE__USERI__671F4F74");

            entity.HasOne(d => d.Usertype).WithMany(p => p.UserTypeMappings)
                .HasForeignKey(d => d.Usertypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USER_TYPE__USERT__681373AD");
        });

        modelBuilder.Entity<Verification>(entity =>
        {
            entity.HasKey(e => e.Verid).HasName("PK__VERIFICA__8AEF72289B066EEA");

            entity.ToTable("VERIFICATION");

            entity.Property(e => e.Verid).HasColumnName("VERID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DT");
            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.Verificationstatus).HasColumnName("VERIFICATIONSTATUS");
            entity.Property(e => e.Verificationtoken)
                .HasColumnType("text")
                .HasColumnName("VERIFICATIONTOKEN");
            entity.Property(e => e.VerifiedDt)
                .HasColumnType("datetime")
                .HasColumnName("VERIFIED_DT");

            entity.HasOne(d => d.User).WithMany(p => p.Verifications)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VERIFICAT__USERI__7B264821");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
