using Laboration_1_Rasmus_Serrestam.ViewModels;

namespace Laboration_1_Rasmus_Serrestam.Views;

public partial class ItemDetailsPage : ContentPage
{
    public ItemDetailsPage(ItemDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}