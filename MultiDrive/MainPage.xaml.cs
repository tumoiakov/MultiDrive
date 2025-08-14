using Microsoft.EntityFrameworkCore;
using MultiDrive.Shared.Database;
using System.Diagnostics;

namespace MultiDrive
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly AppDbContext _context;

        public MainPage(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
            var migrations = _context.Database.GetPendingMigrations().ToList();
            foreach(var migration in migrations)
            {
                Debug.WriteLine($"Applied Migration: {migration}");
            }
        }
    }
}
