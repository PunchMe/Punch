using System;
using Xunit;

namespace Punch.Core.Tests.DayTests
{
    public class Given_A_Day_Without_Times_When_Getting_Total
    {
        [Fact]
        public void Then_It_Should_Return_Zero()
        {
            var day = new Day(new DateTime(2015, 6, 20));

            Assert.Equal(TimeSpan.FromSeconds(0), day.Total);
        }
    }
}