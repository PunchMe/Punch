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

namespace Punch.Core.Tests.DayTests
{
    public class Given_A_Date_When_Constructing
    {
        [Fact]
        public void Then_It_Should_Set_The_Date()
        {
            var day = new Day(new DateTime(2015, 3, 2));

            Assert.Equal(new DateTime(2015, 3, 2), day.Date);
        }
    }
}