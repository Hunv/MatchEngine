using MatchEngine.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.MatchLogic
{
    public static class MatchCore
    {
        public static List<MatchHandler> OngoingMatches { get; private set; } = new List<MatchHandler>();

        public static void AddOngoingMatch(MatchHandler matchHandler)
        {
            matchHandler.DisposeMatchHandler += MatchHandler_DisposeMatchHandler;
            OngoingMatches.Add(matchHandler);
        }

        private static void MatchHandler_DisposeMatchHandler(object sender, EventArgs e)
        {
            OngoingMatches.Remove((MatchHandler)sender);
        }
    }
}
