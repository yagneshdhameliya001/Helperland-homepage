using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HelperlandTatvasoft.Models
{
    public partial class HelperLandContext : DbContext
    {
        public HelperLandContext()
        {
        }

        public HelperLandContext(DbContextOptions<HelperLandContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=HelperLand;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fname")
                    .IsFixedLength(true);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lname")
                    .IsFixedLength(true);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("message")
                    .IsFixedLength(true);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .HasColumnName("subject")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
