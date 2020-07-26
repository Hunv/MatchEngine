using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class Club
    {
        /// <summary>
        /// The internal ID of the Club
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The official Name of the Club
        /// Example: ETSV Schlickteufel e.V.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The Displayname of the Club
        /// Example: Schlickteufel
        /// </summary>
        [Required]
        public string Displayname { get; set; }

        /// <summary>
        /// The Short Name to display at Dashboards etc
        /// Example: ETSV
        /// </summary>
        [Required]
        [MaxLength(5)]
        public string Shortname { get; set; }
    }
}
