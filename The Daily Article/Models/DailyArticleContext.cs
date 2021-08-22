using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TheDailyArticle.Models
{
    public partial class DailyArticleContext : DbContext
    {
        public DailyArticleContext()
        {
        }

        public DailyArticleContext(DbContextOptions<DailyArticleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Members> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=DailyArticle;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>(entity =>
            {
                entity.Property(e => e.PhotoDescription)
                    .IsRequired()
                    .HasColumnName("photoDescription")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Photos)
                    .IsRequired()
                    .HasColumnName("photos")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.Property(e => e.EmailAddress)
                    .HasColumnName("emailAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
