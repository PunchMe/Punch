using System;
using Xunit;

namespace Punch.Core.Tests.DayTests
{
    public class Given_Lunch_Is_Shorter_Than_30_Minutes
    {
        private Day _day;

        public Given_Lunch_Is_Shorter_Than_30_Minutes()
        {
            _day = new Day(new DateTime());
            _day.AddTime(new TimeSpan(0, 8, 0, 0));
            _day.AddTime(new TimeSpan(0, 12, 0, 0));
            _day.AddTime(new TimeSpan(0, 12, 15, 0));
            _day.AddTime(new TimeSpan(0, 16, 30, 0));
        }

        [Fact]
        public void Then_Lunch_Duration_Should_Be_30_Minutes()
        {
            Assert.Equal(new TimeSpan(0, 0, 30, 0), _day.LunchDuration); 
        }

        [Fact]
        public void Then_Total_Should_Take_Lunch_Of_30_Minutes_Into_Account()
        {
            Assert.Equal(new TimeSpan(0, 8, 0, 0), _day.Total); 
        }
    }
}