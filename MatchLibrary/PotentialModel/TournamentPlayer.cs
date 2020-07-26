using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class TournamentPlayer
    {
        /// <summary>
        /// Internal Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Playernumber like it is on the shirt, cap, pants, ...
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// The Team the player is playing with
        /// </summary>
        [Required]
        public TournamentTeam Team {get;set;}

        /// <summary>
        /// The Playerdata
        /// </summary>
        [Required]
        public Player BasePlayer { get; set; }
    }
}
