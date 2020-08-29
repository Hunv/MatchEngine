using MatchLibrary.ApiModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.DatabaseModel
{
    public class Club
    {
        public Club() { }
        public Club(DtoClub club)
        {
            FromDto(club);
        }

        /// <summary>
        /// The ID of the team
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The offical Name of the Team
        /// </summary>
        [Required]
        public string OfficialName { get; set; }

        /// <summary>
        /// The number of the club of the association the club is Member of (VDST, FFESSM, ...)
        /// </summary>
        public string Clubnumber { get; set; }

        /// <summary>
        /// The contact in the club
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }


        /// <summary>
        /// Converts the object to a DTO object
        /// </summary>
        /// <returns></returns>
        public DtoClub ToDto()
        {
            var dto = new DtoClub()
            {
                Id = Id,
                Clubnumber = Clubnumber,
                Contact = Contact,
                Notes = Notes,
                OfficalName = OfficialName
            };

            return dto;
        }

        /// <summary>
        /// Converts the object from a DTO object
        /// </summary>
        /// <param name="dto"></param>
        public void FromDto(DtoClub dto)
        {
            Id = dto.Id;
            Clubnumber = dto.Clubnumber;
            Contact = dto.Contact;
            Notes = dto.Notes;
            OfficialName = dto.OfficalName;
        }
    }
}
