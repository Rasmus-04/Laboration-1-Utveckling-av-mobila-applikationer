using System.Collections.ObjectModel;
using System.Windows.Input;
using Laboration_1_Rasmus_Serrestam.Models;
using Laboration_1_Rasmus_Serrestam.Services;

namespace Laboration_1_Rasmus_Serrestam.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly ItemService _itemService;

        public ObservableCollection<Item> Items { get; } = new();

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public ICommand LoadItemsCommand { get; }

        public MainPageViewModel(ItemService itemService)
        {
            _itemService = itemService;

            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
        }

        public async Task LoadItemsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var items = await _itemService.GetAllItemsAsync();

                Items.Clear();

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
