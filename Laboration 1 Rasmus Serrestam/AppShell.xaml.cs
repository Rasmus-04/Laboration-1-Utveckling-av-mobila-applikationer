using Laboration_1_Rasmus_Serrestam.ViewModels;

namespace Laboration_1_Rasmus_Serrestam
{
    public partial class AppShell : Shell
    {
        public AppShell(MainPage mainPage)
        {
            InitializeComponent();

            Items.Add(new ShellContent
            {
                Title = "Marketplace",
                Content = mainPage,
                Route = "MainPage"
            });
        }
    }
}
