using Laboration_1_Rasmus_Serrestam.ViewModels;

namespace Laboration_1_Rasmus_Serrestam
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadItemsAsync();
        }
    }
}
