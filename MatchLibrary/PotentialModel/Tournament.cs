using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class Tournament
    {
        /// <summary>
        /// Internal Id of the tournament
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the tournament (i.e. "Schlickteufel Cup 2020")
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The Location of the tournament (i.e. "Badepark Elmshorn")
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The start Date of the tournament
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end Date of the tournament
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The Teams that are participating at the tournament
        /// </summary>
        [Required]
        public List<TournamentTeam> TeamList { get;set; }
    }
}
