// Copyright:      ArcelorMittal Gent
//  
// This code may be used in compiled form in any way you desire but may not be 
// redistributed without explicit permission from the authors.  This file is
// intellectual property owned by Arcelor Mittal Ghent and may not be changed.
// This software is provided "as is," without warranty of any kind, express or
// implied. In no event shall the author or contributors be held liable for any
// damages arising in any way from the use of this software.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Punch.Core
{
    public class Times : IEnumerable<TimeSpan>
    {
        private readonly IList<TimeSpan> _times = new List<TimeSpan>();

        public Times(string timesText)
        {
            var timeSeparatorPosition = timesText.IndexOf(':');
            while (timeSeparatorPosition != -1)
            {
                var validationToken = GetValidationToken(timesText, timeSeparatorPosition);
                if (validationToken != ValidationTokens.Cancelled)
                {
                    TimeSpan time;
                    if (TimeSpan.TryParse(timesText.Substring(timeSeparatorPosition - 2, 5), out time))
                    {
                        _times.Add(time);
                    }
                }

                timesText = timesText.Substring(timeSeparatorPosition + 5);
                timeSeparatorPosition = timesText.IndexOf(':');
            }
        }

        private static string GetValidationToken(string timeText, int timeSeparatorPosition)
        {
            var startOfValidationToken = timeText.IndexOf('(', timeSeparatorPosition);
            var endOfValidationToken = timeText.IndexOf(')', startOfValidationToken);
            var validationToken = timeText.Substring(startOfValidationToken, endOfValidationToken - startOfValidationToken + 1);
            return validationToken;
        }

        public IEnumerator<TimeSpan> GetEnumerator()
        {
            return _times.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}