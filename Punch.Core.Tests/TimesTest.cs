// Copyright:      ArcelorMittal Gent
//  
// This code may be used in compiled form in any way you desire but may not be 
// redistributed without explicit permission from the authors.  This file is
// intellectual property owned by Arcelor Mittal Ghent and may not be changed.
// This software is provided "as is," without warranty of any kind, express or
// implied. In no event shall the author or contributors be held liable for any
// damages arising in any way from the use of this software.

using System;
using System.Linq;
using Xunit;

namespace Punch.Core.Tests
{
    public class Given_A_String_When_Constructing_Times
    {
        [Fact]
        public void Then_It_Should_Parse_All_Times()
        {
            var times = new Times("08:00 (V) - 08:30 (V)");

            Assert.Equal(2, times.Count());

            Assert.Equal(new TimeSpan(8, 0, 0), times.ToList()[0]);
            Assert.Equal(new TimeSpan(8, 30, 0), times.ToList()[1]);
        }
    }
}