using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.MatchLogic
{
    public static class MatchCore
    {
        public static List<MatchHandler> OngoingMatches { get; set; } = new List<MatchHandler>();
    }
}
