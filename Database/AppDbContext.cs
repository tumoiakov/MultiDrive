
using Microsoft.EntityFrameworkCore;
using MultiDrive.Models;

namespace MultiDrive.Database
{
    internal class AppDbContext: DbContext
    {
        public DbSet<FileSystemItem> FileSystemItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={Constants.DBPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileSystemItem>()
                .Property(item => item.Id)
                .ValueGeneratedOnAdd(); // Указываем, что значение будет генерироваться автоматически
        }
    }
}
