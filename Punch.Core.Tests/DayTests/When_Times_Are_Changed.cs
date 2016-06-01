using System;
using System.Collections.Generic;
using Xunit;

namespace Punch.Core.Tests.DayTests
{
    public class When_Times_Are_Changed 
    {
        private bool _isTriggerd;
        private Day _day;

        public When_Times_Are_Changed()
        {
            _day = new Day(new DateTime(2015, 3, 2));

            _day.TimesChanged += () =>
            {
                _isTriggerd = true;
            };

            _day.Times = new List<TimeSpan>();
        }

        [Fact]
        public void Then_Trigger_Times_Changed()
        {           
            Assert.True(_isTriggerd);
        }
    }
}