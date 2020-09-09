using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dbfirst
{
    public partial class dbfirstContext : DbContext
    {
        public dbfirstContext()
        {
        }

        public dbfirstContext(DbContextOptions<dbfirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Table1> Table1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("host=localhost;database=dbfirst;user id=postgres;password=integrall;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table1>(entity =>
            {
                entity.ToTable("table1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
