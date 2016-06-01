using System;
using System.Linq;
using Xunit;

namespace Punch.Core.Tests
{
    public class MonthTests
    {
        [Fact]
        public void When_Adding_DateTimes_Then_It_Should_Add_The_Times_To_The_Correct_Days()
        {
            var month = new Month(2015, 1);
            var dateTime1 = new DateTime(2015, 2, 2, 8, 30, 0);
            var dateTime2 = new DateTime(2015, 2, 3, 8, 45, 0);
            var dateTime3 = new DateTime(2015, 2, 2, 12, 30, 0);

            month.AddDateTime(dateTime1);
            month.AddDateTime(dateTime2);
            month.AddDateTime(dateTime3);

            Assert.Equal(2, month.Days.Count(x => !x.Key.IsWeekend() && x.Value.Times.Any()));

            Assert.Equal(2, month.Days[new DateTime(2015, 2, 2)].Times.Count());
            Assert.Equal(new TimeSpan(8, 30, 0), month.Days[new DateTime(2015, 2, 2)].Times.ToList()[0]);
            Assert.Equal(new TimeSpan(12, 30, 0), month.Days[new DateTime(2015, 2, 2)].Times.ToList()[1]);

            Assert.Equal(1, month.Days[new DateTime(2015, 2, 3)].Times.Count());
            Assert.Equal(new TimeSpan(8, 45, 0), month.Days[new DateTime(2015, 2, 3)].Times.ToList()[0]);
        }

        [Fact]
        public void When_Adding_Uneven_DateTimes_Then_It_Should_Return_The_Correct_Total()
        {
            var month = new Month(2015, 2);
            var dateTime1 = new DateTime(2015, 2, 2, 8, 30, 0);
            var dateTime2 = new DateTime(2015, 2, 3, 8, 45, 0);
            var dateTime3 = new DateTime(2015, 2, 2, 12, 30, 0);

            month.AddDateTime(dateTime1);
            month.AddDateTime(dateTime2);
            month.AddDateTime(dateTime3);

            Clock.Set(new TimeSpan(9, 0, 0));
            Calendar.Set(new DateTime(2015, 2, 3));

            Assert.Equal(new TimeSpan(4, 15, 0), month.Total);
        }

        [Fact]
        public void When_Adding_Even_DateTimes_Then_It_Should_Return_The_Correct_Total()
        {
            var month = new Month(2015, 1);
            var dateTime1 = new DateTime(2015, 2, 2, 8, 30, 0);
            var dateTime2 = new DateTime(2015, 2, 2, 12, 30, 0);
            var dateTime3 = new DateTime(2015, 2, 2, 13, 0, 0);
            var dateTime4 = new DateTime(2015, 2, 2, 17, 0, 0);

            month.AddDateTime(dateTime1);
            month.AddDateTime(dateTime2);
            month.AddDateTime(dateTime3);
            month.AddDateTime(dateTime4);

            Assert.Equal(TimeSpan.FromHours(8), month.Total);
        }

        [Fact]
        public void When_Adding_DateTimes_Over_Multiple_Days_Then_It_Should_Return_The_Correct_Maximum()
        {
            var month = new Month(2015, 1);
            var dateTime1 = new DateTime(2015, 2, 2, 8, 30, 0);
            var dateTime2 = new DateTime(2015, 2, 2, 12, 30, 0);
            var dateTime3 = new DateTime(2015, 2, 2, 12, 45, 0);
            var dateTime4 = new DateTime(2015, 2, 2, 17, 0, 0);

            var dateTime5 = new DateTime(2015, 2, 3, 8, 30, 0);
            var dateTime6 = new DateTime(2015, 2, 3, 12, 30, 0);
            var dateTime7 = new DateTime(2015, 2, 3, 12, 45, 0);

            month.AddDateTime(dateTime1);
            month.AddDateTime(dateTime2);
            month.AddDateTime(dateTime3);
            month.AddDateTime(dateTime4);
            month.AddDateTime(dateTime5);
            month.AddDateTime(dateTime6);
            month.AddDateTime(dateTime7);

            Assert.Equal(TimeSpan.FromHours(16), month.Maximum);
        }

        [Fact]
        public void When_Creating_A_Month_All_Days_Should_Already_Have_Been_Added()
        {
            var month = new Month(2015, 1);

            Assert.Equal(31, month.Days.Count);
        }

        [Fact]
        public void When_Creating_A_Month_The_MonthNumber_And_Year_Should_Be_Set()
        {
            var month = new Month(2015, 1);

            Assert.Equal(1, month.MonthNumber);
            Assert.Equal(2015, month.YearNumber);
        }
    }
}
