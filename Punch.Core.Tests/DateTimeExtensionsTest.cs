// Copyright:      ArcelorMittal Gent
//  
// This code may be used in compiled form in any way you desire but may not be 
// redistributed without explicit permission from the authors.  This file is
// intellectual property owned by Arcelor Mittal Ghent and may not be changed.
// This software is provided "as is," without warranty of any kind, express or
// implied. In no event shall the author or contributors be held liable for any
// damages arising in any way from the use of this software.

using System;
using Xunit;

namespace Punch.Core.Tests
{
    public class DateTimeExtensionsTest
    {
        [Fact]
        public void IsWeekendShouldReturnTrueForSaturdayAndSunday()
        {
            Assert.True(new DateTime(2015, 6, 6).IsWeekend());
            Assert.True(new DateTime(2015, 6, 7).IsWeekend());
        }

        [Fact]
        public void IsWeekendShouldReturnFalseForWeekDays()
        {
            Assert.False(new DateTime(2015, 6, 8).IsWeekend());
            Assert.False(new DateTime(2015, 6, 9).IsWeekend());
            Assert.False(new DateTime(2015, 6, 10).IsWeekend());
            Assert.False(new DateTime(2015, 6, 11).IsWeekend());
            Assert.False(new DateTime(2015, 6, 12).IsWeekend());
        }
    }
}