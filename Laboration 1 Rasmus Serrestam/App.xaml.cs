using Laboration_1_Rasmus_Serrestam.Data;

namespace Laboration_1_Rasmus_Serrestam;

public partial class App : Application
{
    private readonly DatabaseInitializer _databaseInitializer;
    private readonly AppShell _appShell;

    public App(DatabaseInitializer databaseInitializer, AppShell appShell)
    {
        InitializeComponent();

        _databaseInitializer = databaseInitializer;
        _appShell = appShell;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Visa en laddningsindikator medan databasen initieras.
        var window = new Window(new ContentPage
        {
            Content = new ActivityIndicator
            {
                IsRunning = true,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            }
        });

        InitializeDatabaseAsync(window);

        return window;
    }

    private async void InitializeDatabaseAsync(Window window)
    {
        try
        {
            await _databaseInitializer.InitializeAsync();

            // Visa appens startsida när databasen är klar.
            window.Page = _appShell;
        }
        catch (Exception ex)
        {
            window.Page = new ContentPage
            {
                Content = new Label
                {
                    Text = $"Could not initialize database: {ex.Message}",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                }
            };
        }
    }
}
