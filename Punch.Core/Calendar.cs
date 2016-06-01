using System;

namespace Punch.Core
{
    public static class Calendar
    {
        private static DateTime? _value;

        public static DateTime Date()
        {
            return _value ?? DateTime.Now.Date;
        }

        public static void Set(DateTime value)
        {
            _value = value;
        }

        public static void Reset()
        {
            _value = null;
        }
    }
}