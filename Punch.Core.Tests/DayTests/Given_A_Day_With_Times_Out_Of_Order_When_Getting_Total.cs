using System;
using Xunit;

namespace Punch.Core.Tests.DayTests
{
    public class Given_A_Day_With_Times_Out_Of_Order_When_Getting_Total
    {
        [Fact]
        public void Then_It_Should_Return_The_Sum_Of_The_Times()
        {
            var day = new Day(new DateTime(2015, 3, 2));
            day.AddTime(new TimeSpan(12, 30, 0));
            day.AddTime(new TimeSpan(17, 0, 0));
            day.AddTime(new TimeSpan(13, 0, 0));
            day.AddTime(new TimeSpan(8, 30, 0));

            Assert.Equal(TimeSpan.FromHours(8), day.Total);
        }
    }
}