// Copyright:      ArcelorMittal Gent
//  
// This code may be used in compiled form in any way you desire but may not be 
// redistributed without explicit permission from the authors.  This file is
// intellectual property owned by Arcelor Mittal Ghent and may not be changed.
// This software is provided "as is," without warranty of any kind, express or
// implied. In no event shall the author or contributors be held liable for any
// damages arising in any way from the use of this software.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Punch.Core
{
    public class Day : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Action TimesChanged = () => { };

        private IList<TimeSpan> _times = new List<TimeSpan>();
        private readonly TimeSpan _mandatoryLunchTime = new TimeSpan(0, 0, 30, 0);

        public Day(DateTime date)
        {
            Date = date.Date;
        }

        public void AddTime(TimeSpan time)
        {
            _times.Add(time);
            _times = _times.OrderBy(x => x).ToList();
        }

        public IEnumerable<TimeSpan> Times
        {
            get { return _times; }
            set
            {
                _times = value.ToList();
                TimesChanged();
                RaisePropertyChanged();
            }
        }

        public DateTime Date { get; private set; }

        public TimeSpan Total
        {
            get
            {
                if (!_times.Any())
                {
                    return TimeSpan.FromSeconds(0);
                }

                var result = TimeSpan.FromSeconds(0);

                for (var i = 0; i < _times.Count; i = i + 2)
                {
                    var start = _times[i];

                    var stop = start;
                    var nextIndex = i + 1;
                    if (nextIndex < _times.Count)
                    {
                        stop = _times[nextIndex];
                    }
                    else if (Calendar.Date() == Date)
                    {
                        stop = Clock.Read();
                    }

                    result += stop - start;
                }

                if (LunchDuration != new TimeSpan(0) && GetActualLunchDuration() < _mandatoryLunchTime)
                {
                    result = result - (_mandatoryLunchTime - GetActualLunchDuration());
                }

                return result;
            }
        }

        private TimeSpan GetActualLunchDuration()
        {
            if (_times.Count >= 3)
            {
                var lunchStart = _times[1];
                var lunchEnd = _times[2];
                var lunchTime = lunchEnd.Subtract(lunchStart);

                return lunchTime;
            }

            return new TimeSpan(0);
        }        
        
        public TimeSpan LunchDuration
        {
            get
            {
                var actualLunchDuration = GetActualLunchDuration();

                if (actualLunchDuration == new TimeSpan(0) || actualLunchDuration > _mandatoryLunchTime)
                {
                    return actualLunchDuration;
                }

                return _mandatoryLunchTime;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChanged()
        {
            OnPropertyChanged("");
        }
    }
}