using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class MatchInfo
    {
        /// <summary>
        /// Internal Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The actual Starttime of the match
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The planned starttime of the match
        /// </summary>
        [Required]
        public DateTime PlannedStartTime { get; set; }

        /// <summary>
        /// Is the match ongoing?
        /// </summary>
        [Required]
        public bool IsMatchRunning { get; set; }

        /// <summary>
        /// Scores of Team 1
        /// </summary>
        [Required]
        public List<MatchGoal> Team1Score { get; set; }

        /// <summary>
        /// Scores of Team 2
        /// </summary>
        [Required]
        public List<MatchGoal> Team2Score { get; set; }

        /// <summary>
        /// The seconds left of current Halftime
        /// </summary>
        [Required]
        public int RemainingSecondsHalftime { get; set; }

        /// <summary>
        /// The current halftime (0-based)
        /// </summary>
        [Required]
        public int CurrentHalftime { get; set; }

        /// <summary>
        /// The List of Referees
        /// </summary>
        [Required]
        public List<MatchPlayer> RefereeList { get; set; }

        /// <summary>
        /// The settings for the match
        /// </summary>
        [Required]
        public MatchConfiguration MatchConfiguration { get; set; }


        /// <summary>
        /// Team1 of this match
        /// </summary>
        [Required]
        public MatchTeam Team1 { get; set; }

        /// <summary>
        /// Team2 of this match
        /// </summary>
        [Required]
        public MatchTeam Team2 { get; set; }
    }
}
