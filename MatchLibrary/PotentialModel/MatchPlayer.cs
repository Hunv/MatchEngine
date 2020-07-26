using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class MatchPlayer
    {
        /// <summary>
        /// Internal Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A comment by Referees to the player
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Is the player playing that game?
        /// </summary>
        [Required]
        public bool IsPlaying { get; set; } = true;

        /// <summary>
        /// The Player is a Referee for the given Match
        /// </summary>
        public MatchInfo RefereeMatch { get; set; }
        
        /// <summary>
        /// The Base Information for this Player
        /// </summary>
        [Required]
        public TournamentPlayer Player { get; set; }
        
    }
}
