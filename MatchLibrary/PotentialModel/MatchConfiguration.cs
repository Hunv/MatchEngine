using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class MatchConfiguration
    {
        /// <summary>
        /// The internal MatchId
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The over all duration of all regular halftimes
        /// </summary>
        [Required]
        public List<MatchHalftime> Halftimes { get; set; }

        /// <summary>
        /// Duration of a team timeout
        /// The lenght in seconds of a team timeout.
        /// 0 = No Timeout or no fixed length
        /// </summary>
        public int DurationTimeoutSeconds { get; set; } = 0;

        /// <summary>
        /// Number of Score in case of a Goal Type 1 
        /// Examples: 1 for most games but i.e. 15 for Tennis or 2 for Basketball
        /// </summary>
        [Required]
        public int ScoreGoalType1 { get; set; } = 1;

        /// <summary>
        /// Number of Score in case of a Goal Type 2 
        /// Examples: 0 = unused, i.e. 10 for Tennis or 3 for Basketball
        /// </summary>
        [Required]
        public int ScoreGoalType2 { get; set; } = 0;

        /// <summary>
        /// Number of Score in case of a Goal Type 3 (0 = unused, i.e. 1 for Basketball)
        /// </summary>
        [Required]
        public int ScoreGoalType3 { get; set; } = 0;
    }
}
