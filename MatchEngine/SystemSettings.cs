using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine
{
    public static class SystemSettings
    {
        /// <summary>
        /// The ms of time after a finished match will be removed from MatchHandler
        /// </summary>
        public static int MatchHandlerDisposeTime { get; set; } = 600000; //Default: 10 Minutes

        /// <summary>
        /// The ms of time the matchhandler will check if a second is gone and updates the time
        /// </summary>
        public static int MatchHandlerRefreshTime { get; set; } = 50; //Default: 50ms
    }
}
