using MultiDrive.Shared.Database;

namespace MultiDrive
{
    public partial class App : Application
    {
        public App(AppDbContext context)
        {
            InitializeComponent();
            context.InitializeDatabase();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}