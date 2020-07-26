using MatchLibrary.ApiModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchEngine.DatabaseModel
{
    public class StandaloneMatch
    {
        /// <summary>
        /// A dummy Id for the standalone match
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The teams, that participate on that match
        /// </summary>
        public List<StandaloneTeam> Teams { get; set; }

        /// <summary>
        /// The time left of the ongoing Standalone Match
        /// </summary>
        public int SecondsLeft { get; set; }
    }
}
