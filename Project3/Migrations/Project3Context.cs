using System;
using System.Collections.Generic;
using Project3.Models;
using Microsoft.EntityFrameworkCore;

namespace Project3.Migrations;

public partial class Project3Context : DbContext
{
    public Project3Context()
    {
    }

    public Project3Context(DbContextOptions<Project3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<CategoryBlog> CategoryBlogs { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<InformationStudent> InformationStudents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<TestFirst> TestFirsts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-ASJD1ADE;Initial Catalog=Project3;TrustServerCertificate=True;Persist Security Info=True;User ID=sa;Password=123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blogs__3214EC07893C2F39");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Summay).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(1);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Blogs__CategoryI__48CFD27E");

            entity.HasOne(d => d.Users).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK__Blogs__UsersId__4AB81AF0");
        });

        modelBuilder.Entity<CategoryBlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07AA04A19E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(1);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMMENTS__3214EC07A87A6D60");

            entity.ToTable("COMMENTS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CommentDate).HasColumnType("datetime");
            entity.Property(e => e.CommentMsg).HasMaxLength(1);

            entity.HasOne(d => d.Blog).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK__COMMENTS__BlogId__4D94879B");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__COMMENTS__UserId__4E88ABD4");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07208C2447");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CoursesName).HasMaxLength(1);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<InformationStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Informat__3214EC070501D268");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DateBirth).HasColumnType("datetime");
            entity.Property(e => e.EndCard).HasColumnType("datetime");
            entity.Property(e => e.FromCard).HasMaxLength(1);
            entity.Property(e => e.FullName).HasMaxLength(1);
            entity.Property(e => e.IdCardStudent).HasMaxLength(255);
            entity.Property(e => e.IdentityCard).HasMaxLength(255);
            entity.Property(e => e.StartCard).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            entity.Property(e => e.WasBorn).HasMaxLength(1);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.InformationStudent)
                .HasForeignKey<InformationStudent>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InformationS__Id__49C3F6B7");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC073F559D59");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NameRole).HasMaxLength(255);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC073B406A69");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.SubjectName).HasMaxLength(1);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Courses).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.CoursesId)
                .HasConstraintName("FK__Subjects__Course__4CA06362");
        });

        modelBuilder.Entity<TestFirst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TestFirs__3214EC0737F13765");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.NameTest).HasMaxLength(1);

            entity.HasOne(d => d.InfoStudent).WithMany(p => p.TestFirsts)
                .HasForeignKey(d => d.InfoStudentId)
                .HasConstraintName("FK__TestFirst__InfoS__4BAC3F29");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F925BBC1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasColumnType("varbinary(max)");
            entity.Property(e => e.PasswordSalt).HasColumnType("varbinary(max)");
            entity.Property(e => e.UserName).HasMaxLength(1);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC07E34239A0");

            entity.ToTable("UserRole");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRole__RoleId__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRole__UserId__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
