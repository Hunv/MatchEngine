using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.DatabaseModel
{
    public class Team2Match
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}
