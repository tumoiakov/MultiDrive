
using Microsoft.EntityFrameworkCore;
using MultiDrive.Shared.Models;

namespace MultiDrive.Shared.Database
{
    public class AppDbContext: DbContext
    {
        public DbSet<FileSystemItem> FileSystemItems { get; set; }

        public string DbPath { get; }

        public AppDbContext()
        {
            DbPath = Path.Combine("../", "MultiDrive.db");
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public void InitializeDatabase()
        {
            SQLitePCL.Batteries_V2.Init();

            if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
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
