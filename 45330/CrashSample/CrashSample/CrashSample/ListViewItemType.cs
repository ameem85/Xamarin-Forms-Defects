using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrashSample
{
    public class ListViewItemType : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value == _isSelected)
                {
                    return;
                }

                _isSelected = value;
                OnPropertyChanged();
            }
        }

        private string _itemName;
        public string ItemName
        {
            get => _itemName;
            set
            {
                if (value == _itemName)
                {
                    return;
                }
                _itemName = value;
                OnPropertyChanged();
            }
        }
    }
}
