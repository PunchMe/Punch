// Copyright:      ArcelorMittal Gent
//  
// This code may be used in compiled form in any way you desire but may not be 
// redistributed without explicit permission from the authors.  This file is
// intellectual property owned by Arcelor Mittal Ghent and may not be changed.
// This software is provided "as is," without warranty of any kind, express or
// implied. In no event shall the author or contributors be held liable for any
// damages arising in any way from the use of this software.

using TimesheetFetcher.New;
using Xunit;

namespace TimesheetFetcher.Tests
{
    public class ClockTest
    {
        [Fact]
        public void The_Clock_Should_Have_A_Precision_To_Minutes()
        {
            var result = Clock.Read();

            Assert.Equal(0, result.Seconds);
            Assert.Equal(0, result.Milliseconds);
        }
    }
}