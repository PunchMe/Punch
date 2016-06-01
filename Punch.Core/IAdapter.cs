using System.Collections.Generic;

namespace Punch.Core
{
    public interface IAdapter
    {
        /// <summary>
        /// The current settings for this instance.
        /// </summary>
        IList<AdapterSetting> Settings { get; set; }

        /// <summary>
        /// The keys of the settings this instance accepts.
        /// </summary>
        IList<PossibleAdapterSetting> PossibleSettings { get; }

        Month ProcessMonth(Month month);
    }
}