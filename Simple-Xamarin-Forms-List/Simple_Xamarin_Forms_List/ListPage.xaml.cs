using Simple_Xamarin_Forms_List.Model;
using Simple_Xamarin_Forms_List.Services;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simple_Xamarin_Forms_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        private SearchService _searchService;
        private ObservableCollection<History> _history;

        public ListPage()
        {
            _searchService = new SearchService();

            InitializeComponent();

            _searchService.GetHistory();
        }


        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = _searchService.GetHistory(e.NewTextValue);
        }


        // Pull to Refresh
        private void ListView_OnRefreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = _searchService.GetHistory(searchBar.Text);
            //searchBar.Text = "";
            listView.EndRefresh();
        }


        // Delete history item
        private void Delete_OnClicked(object sender, EventArgs e)
        {
            var history = (sender as MenuItem)?.CommandParameter as History;
            _history.Remove(history);
        }


        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var history = e.SelectedItem as History;
            if (history != null)
            {
                var location = history.Location;
                DisplayAlert("Location", location, "OK");
            }
        }
    }
}