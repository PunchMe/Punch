using System;
using System.Linq;
using Xunit;

namespace Punch.Core.Tests.DayTests
{
    public class Given_A_Day_With_Times_When_Adding_Time
    {
        [Fact]
        public void Then_It_Should_Add_The_Time_At_The_Correct_Position()
        {
            var day = new Day(new DateTime(2015, 3, 2));

            day.AddTime(new TimeSpan(1, 30, 0));
            day.AddTime(new TimeSpan(2, 30, 0));

            day.AddTime(new TimeSpan(2, 0, 0));

            Assert.Equal(new TimeSpan(1, 30, 0), day.Times.ToList()[0]);
            Assert.Equal(new TimeSpan(2, 0, 0), day.Times.ToList()[1]);
            Assert.Equal(new TimeSpan(2, 30, 0), day.Times.ToList()[2]);
        }
    }
}