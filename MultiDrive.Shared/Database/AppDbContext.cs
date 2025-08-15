
using Microsoft.EntityFrameworkCore;
using MultiDrive.Shared.Models;
using System.Diagnostics;

namespace MultiDrive.Shared.Database
{
    public class AppDbContext: DbContext
    {
        public DbSet<FileSystemItem> FileSystemItems { get; set; }

        public string? DbPath { get; }

        public AppDbContext()
        {
            DbPath = Path.Combine("../", "MultiDrive.db");
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            SQLitePCL.Batteries_V2.Init();
        }

        public void InitializeDatabase()
        {
            bool isTherePendingMigrations = Database.GetPendingMigrations().Any();

            if (isTherePendingMigrations)
            {
                Database.Migrate(); // Apply pending migrations
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileSystemItem>()
                .Property(item => item.Id)
                .ValueGeneratedOnAdd(); // Указываем, что значение будет генерироваться автоматически
        }

        public void ReloadDatabase()
        {
            Database.CloseConnection();
            Database.OpenConnection();
        }
    }
}
