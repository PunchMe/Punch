using System;
using System.Linq;
using Xunit;

namespace Punch.Core.Tests.DayTests
{
    public class Given_A_Day_When_Adding_Time
    {
        [Fact]
        public void Then_It_Should_Contain_The_Time()
        {
            var day = new Day(new DateTime(2015, 3, 2));
            var time = new TimeSpan(1, 30, 0);

            day.AddTime(time);

            Assert.Equal(time, day.Times.Single());
        }
    }
}