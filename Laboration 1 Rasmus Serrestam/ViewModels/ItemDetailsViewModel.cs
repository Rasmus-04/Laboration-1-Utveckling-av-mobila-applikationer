using Laboration_1_Rasmus_Serrestam.Models;
using Laboration_1_Rasmus_Serrestam.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboration_1_Rasmus_Serrestam.ViewModels
{
    public class ItemDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly ItemService _itemService;

        private Item? _item;
        public Item? Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        public ItemDetailsViewModel(ItemService itemService)
        {
            _itemService = itemService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("itemId", out var value) && int.TryParse(value?.ToString(), out int itemId))
            {
                _ = LoadItemAsync(itemId);
            }
        }

        private async Task LoadItemAsync(int itemId)
        {
            Item = await _itemService.GetItemByIdAsync(itemId);
        }
    }
}
