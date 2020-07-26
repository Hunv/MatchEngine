using System;
using System.Collections.Generic;
using System.Text;

namespace MatchLibrary.ApiModel
{
    public class DtoStandaloneMatch
    {
        /// <summary>
        /// The teams, that participate on that match
        /// </summary>
        public List<DtoStandaloneTeam> Teams { get; set; }

        /// <summary>
        /// The time left of the ongoing Standalone Match
        /// </summary>
        public int SecondsLeft { get; set; }
    }
}
