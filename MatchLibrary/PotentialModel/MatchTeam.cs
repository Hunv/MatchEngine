using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class MatchTeam
    {
        /// <summary>
        /// Internal Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Base Tournament Team for this Match
        /// </summary>
        [Required]
        public TournamentTeam Team { get; set; }
    }
}
