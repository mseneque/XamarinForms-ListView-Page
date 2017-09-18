using Simple_Xamarin_Forms_List.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Simple_Xamarin_Forms_List.Services
{
    public class SearchService
    {
        // Sets a mock hardcoded history
        private ObservableCollection<History> _history = new ObservableCollection<History>
        {
            new History
            {
                Id = 1,
                Country = Country.Austraila,
                StateAbr = StateAbr.WA,
                Suburb = "Clarkson",
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today.AddDays(2)
            },
            new History
            {
                Id = 2,
                Country = Country.Austraila,
                StateAbr = StateAbr.WA,
                Suburb = "Dianella",
                CheckIn = DateTime.Today.AddDays(3),
                CheckOut = DateTime.Today.AddDays(6)
            },
            new History
            {
                Id = 3,
                Country = Country.Austraila,
                StateAbr = StateAbr.WA,
                Suburb = "Claremont",
                CheckIn = DateTime.Today.AddDays(7),
                CheckOut = DateTime.Today.AddDays(14)
            }
        };


        // Implements History Search
        public IEnumerable<History> GetHistory(string searchString = null)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return _history;

            return _history.Where(s => s.Suburb.StartsWith(searchString, StringComparison.CurrentCultureIgnoreCase));

        }

        // Deletes a history
        public void DeleteHistory(int searchId)
        {
            _history.Remove(_history.Single(s => s.Id == searchId));
        }

    }
}