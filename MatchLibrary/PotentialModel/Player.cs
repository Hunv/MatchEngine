using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class Player
    {
        /// <summary>
        /// Internal ID of a Player
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The First name of the player
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// The Lastname of the player
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// The Name like it is shown of Dashboard etc.
        /// </summary>
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// A Short name of the Player. Usually 3 characters.
        /// </summary>
        [Required]
        public string ShortName { get; set; }

        /// <summary>
        /// The number in the player pass
        /// </summary>
        public int FederationNumber { get; set; }

        /// <summary>
        /// The expiration date of the health certificate
        /// </summary>        
        public DateTime HealthCertificateExpiration { get; set; }

        /// <summary>
        /// The nationality of the player
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// The birthday of the player
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// The sex of the player
        /// </summary>
        public char Sex { get; set; }

        /// <summary>
        /// The referee Level of the player
        /// Null or empty = no level
        /// </summary>
        public string RefereeLevel { get; set; }

        /// <summary>
        /// The expiration date of the referee level
        /// Not relevant if Refereelevel is unset
        /// </summary>
        public DateTime RefereeLevelExpiration { get; set; }

        /// <summary>
        /// The Club of the player
        /// </summary>
        [Required]
        public Club Club { get; set; }

    }
}
