using Simple_Xamarin_Forms_List.Model;
using Simple_Xamarin_Forms_List.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simple_Xamarin_Forms_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        private SearchService _searchService;

        public ListPage()
        {
            _searchService = new SearchService();

            InitializeComponent();

            DisplayList(_searchService.GetHistory());
        }

        private void DisplayList(IEnumerable<History> history)
        {
            listView.ItemsSource = history;
        }


        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DisplayList(_searchService.GetHistory(e.NewTextValue));
        }


        // Pull to Refresh
        private void ListView_OnRefreshing(object sender, EventArgs e)
        {
            DisplayList(_searchService.GetHistory(searchBar.Text));
            listView.EndRefresh();
        }


        // Delete history item
        private void Delete_OnClicked(object sender, EventArgs e)
        {
            var history = (sender as MenuItem)?.CommandParameter as History;
            if (history != null) _searchService.DeleteHistory(history.Id);
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