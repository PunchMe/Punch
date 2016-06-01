// Copyright:      ArcelorMittal Gent
//  
// This code may be used in compiled form in any way you desire but may not be 
// redistributed without explicit permission from the authors.  This file is
// intellectual property owned by Arcelor Mittal Ghent and may not be changed.
// This software is provided "as is," without warranty of any kind, express or
// implied. In no event shall the author or contributors be held liable for any
// damages arising in any way from the use of this software.

using System;
using System.ComponentModel;
using System.Linq;

namespace Punch.Core
{
    public class Month : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ObservableDictionary<DateTime, Day> _days = new ObservableDictionary<DateTime, Day>();

        public Month(int year, int month)
        {
            YearNumber = year;
            MonthNumber = month;

            for (var i = 0; i < DateTime.DaysInMonth(year, month); i++)
            {
                var dateTime = new DateTime(year, month, i + 1);
                var day = new Day(dateTime);
                day.TimesChanged += OnTimesChanged;
                Days.Add(dateTime, day);
            }
        }

        private void OnTimesChanged()
        {
            OnPropertyChanged("");
        }

        public int MonthNumber { get; private set; }
        public int YearNumber { get; private set; }

        public ObservableDictionary<DateTime, Day> Days
        {
            get { return _days; }
        }

        public TimeSpan Total
        {
            get
            {
                return Days
                    .Where(x => !x.Key.IsWeekend() && x.Value.Times.Any())
                    .Select(x => x.Value.Total)
                    .Aggregate(TimeSpan.FromSeconds(0), (t1, t2) => t1.Add(t2));
            }
        }

        public TimeSpan Maximum
        {
            get
            {
                return TimeSpan.FromHours(Days.Count(x => !x.Key.IsWeekend() && x.Value.Times.Any()) * 8);
            }
        }
        
        public TimeSpan Overtime
        {
            get { return Total - Maximum; }
        }

        public void AddDateTime(DateTime dateTime)
        {
            if (!Days.ContainsKey(dateTime.Date))
            {
                Days.Add(dateTime.Date, new Day(dateTime.Date));
            }

            Days[dateTime.Date].AddTime(dateTime.TimeOfDay);
        }
            
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}