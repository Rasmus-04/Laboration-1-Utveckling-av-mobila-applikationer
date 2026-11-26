using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Laboration_1_Rasmus_Serrestam.Models
{
    public class Item : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public ItemCondition Condition { get; set; }

        public string Description { get; set; } = string.Empty;

        public string SellerEmail { get; set; } = string.Empty;

        private bool _isFavorite;

        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                if (_isFavorite != value)
                {
                    _isFavorite = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
