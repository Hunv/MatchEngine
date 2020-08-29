using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.ApiModel
{
    public class DtoClub
    {
        /// <summary>
        /// The ID of the club
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The offical Name of the club
        /// </summary>
        [MaxLength(256, ErrorMessage = "Der Name kann höchstens aus 256 Zeichen bestehen.")]
        [MinLength(2, ErrorMessage = "Der Name muss mindestens aus zwei Zeichen bestehen.")]
        public string OfficalName { get; set; }

        /// <summary>
        /// The clubnumber of the association the club is member of
        /// </summary>
        [MaxLength(256, ErrorMessage = "Die Vereinsnummer kann höchstens aus 256 Zeichen bestehen.")]
        [MinLength(2, ErrorMessage = "Die Vereinsnummer muss mindestens aus zwei Zeichen bestehen.")]
        public string Clubnumber { get; set; }

        /// <summary>
        /// Contact information of the club
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Contact { get; set; }

        /// <summary>
        /// Notes about the Club
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}
