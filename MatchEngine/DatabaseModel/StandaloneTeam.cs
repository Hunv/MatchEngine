using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.DatabaseModel
{
    public class StandaloneTeam
    {
        /// <summary>
        /// Id for Standalone Team
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Current Score of the Team
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// The standalone match this team belongs to
        /// </summary>
        public StandaloneMatch StandaloneMatch { get; set; }
    }
}
