using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class MatchHalftime
    {
        /// <summary>
        /// Internal Id for the Halftime
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Halftime (i.e. "1st Halftime")
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The duration of the halftime in seconds
        /// Example: 15 Minutes = 900; 45 Minutes = 2700
        /// </summary>
        [Required]
        public int DurationSeconds { get; set; }

        /// <summary>
        /// The duration of the break after the halftime. In case it is the last regular halftime, the duration of the break in case of overtime.
        /// 0 = No fixed break length
        /// </summary>
        [Required]
        public int BreakSeconds { get; set; } = 0;

        /// <summary>
        /// Is this halftime a overtime?
        /// </summary>
        [Required]
        public bool IsOvertime { get; set; }

        /// <summary>
        /// The Match this Halftime belongs to
        /// </summary>
        [Required]
        public MatchConfiguration Match { get; set; }
    }
}
