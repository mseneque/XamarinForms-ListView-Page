using System;

namespace Simple_Xamarin_Forms_List.Model
{
    public enum StateAbr { ACT, NT, QLD, SA, TAS, VIC, WA }
    public enum Country { Austraila }

    public class History
    {
        public int Id { get; set; }
        public string Suburb { get; set; }
        public StateAbr StateAbr { get; set; }
        public Country Country { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public string Location => $"{Suburb}, {StateAbr}, {Country}";
        public string Dates => $"{CheckIn:MMM} {CheckIn:dd}, {CheckIn:yyyy} - {CheckOut:MMM} {CheckOut:dd}, {CheckOut:yyyy}";
    }
}
