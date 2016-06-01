using System;
using Xunit;

namespace Punch.Core.Tests.DayTests
{
    public class Given_Lunch_Is_Longer_Than_30_Minutes
    {
        private readonly Day _day;

        public Given_Lunch_Is_Longer_Than_30_Minutes()
        {
            _day = new Day(new DateTime(2015, 3, 2));

            _day.AddTime(new TimeSpan(7, 20, 0));
            _day.AddTime(new TimeSpan(12, 4, 0));
            _day.AddTime(new TimeSpan(12, 35, 0));
            _day.AddTime(new TimeSpan(16, 6, 0));
        }

        [Fact]
        public void Then_Lunch_Duration_Should_Be_Given_Lunch_Duration()
        {            
            Assert.Equal(TimeSpan.FromMinutes(31), _day.LunchDuration);
        }

        [Fact]
        public void Then_Total_Should_Be_Correct()
        {
            Assert.Equal(new TimeSpan(8, 15, 0), _day.Total);
        }
    }
}