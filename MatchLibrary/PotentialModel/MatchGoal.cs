using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class MatchGoal
    {   
        /// <summary>
        /// Internal ID for a Goal
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Amout of scores/points this goal have
        /// Example: 1 at a soccer goal, 2 at a regular basketball goal, 15 or 10 at Tennis, ...
        /// </summary>
        [Required]
        public int ScoreAmount { get; set; }

        /// <summary>
        /// When this Goal happend?
        /// </summary>
        [Required]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The Match this goal belongs to in case of Team1
        /// </summary>
        [Required]
        public MatchInfo MatchTeam1 { get; set; }

        /// <summary>
        /// The Match this goal belongs to in case of Team2
        /// </summary>
        [Required]
        public MatchInfo MatchTeam2 { get; set; }
    }
}
