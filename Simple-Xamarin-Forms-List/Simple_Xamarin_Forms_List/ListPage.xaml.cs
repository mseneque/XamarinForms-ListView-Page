using Simple_Xamarin_Forms_List.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simple_Xamarin_Forms_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        private ObservableCollection<History> _history;

        public ListPage()
        {
            InitializeComponent();

            SetMockHistory();

            listView.ItemsSource = _history;
        }


        // Sets a mock hardcoded history
        public void SetMockHistory()
        {
            _history = new ObservableCollection<History>()
            {
                new History {Country = Country.Austraila, StateAbr = StateAbr.WA, Suburb = "Clarkson", CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(2)},
                new History {Country = Country.Austraila, StateAbr = StateAbr.WA, Suburb = "Dianella", CheckIn = DateTime.Today.AddDays(3), CheckOut = DateTime.Today.AddDays(6)},
                new History {Country = Country.Austraila, StateAbr = StateAbr.WA, Suburb = "Claremont", CheckIn = DateTime.Today.AddDays(7), CheckOut = DateTime.Today.AddDays(14)}
            };
        }


        // Implements Search
        public IEnumerable<History> GetHistory(string searchString = null)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return _history;

            return _history.Where(c => c.Suburb.ToLower().StartsWith(searchString.ToLower()));
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetHistory(e.NewTextValue);
        }

    }
}