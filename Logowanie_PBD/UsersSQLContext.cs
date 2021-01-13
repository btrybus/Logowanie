using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Logowanie_PBD
{
    public partial class UsersSQLContext : DbContext
    {
        public UsersSQLContext()
        {
        }

        public UsersSQLContext(DbContextOptions<UsersSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Uzytkownicy> Uzytkownicies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Uzytkownicy>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("PK__Uzytkown__5E55825AFFDF9CBD");

                entity.ToTable("Uzytkownicy");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Haslo).HasMaxLength(50);

                entity.Property(e => e.Uprawnienia)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
