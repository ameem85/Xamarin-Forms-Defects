using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrashSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrashSitePage : ContentPage
    {
        private ObservableCollection<ListViewItemType> _items;
        public ObservableCollection<ListViewItemType> Items
        {
            get => _items;
            set
            {
                if (value == _items)
                {
                    return;
                }
                _items = value;
                OnPropertyChanged();
            }
        }

        public CrashSitePage()
        {
            InitializeComponent();
            Items = ListViewItemsProvider.Items;
            //ListView.SetBinding(ListView.ItemsSourceProperty, new Binding(".", source: ListViewItemsProvider.Items));
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as ListViewItemType;
            item.IsSelected = !item.IsSelected;
        }


        private void Button_OnClicked(object sender, EventArgs e)
        {
            //Reset the value to null. 
            //since the lifetime of ItemsSource is greater than the page's listview, 
            //resetting items to null to avoid triggering UI changes when any property changes occur on the ListViewItemType
            Items = null;
            Navigation.PopAsync();
        }
    }

    public class ListViewItemsProvider
    {
        public static ObservableCollection<ListViewItemType> Items { get; } = new ObservableCollection<ListViewItemType>(new[]
        {
            new ListViewItemType {ItemName = "Zero"},
            new ListViewItemType {ItemName = "One"},
            new ListViewItemType {ItemName = "Two"},
        });
    }
}