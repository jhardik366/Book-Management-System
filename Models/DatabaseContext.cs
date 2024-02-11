using Microsoft.EntityFrameworkCore;

namespace BookManagement.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C51ACED37");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
