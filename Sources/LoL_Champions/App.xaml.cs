using LoL_Champions.ViewModels;

namespace LoL_Champions
{
    public partial class App : Application
    {
        public AppVM AppVM { get; private set; }

        public App(IServiceProvider service)
        {
            InitializeComponent();
            MainPage = new AppShell();

            AppVM = new AppVM(MainPage.Navigation, service);
        }
    }
}