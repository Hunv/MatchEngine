using MatchLibrary.ApiModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.DatabaseModel
{
    public class Tournament
    {
        public Tournament() { }
        public Tournament(DtoTournament dto)
        {
            FromDto(dto);
        }

        /// <summary>
        /// Internal Id for a tournament
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Tournament
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The Date of the tournament
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// The City where the Tournament is
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The pool, address or whatever where the Tournament is
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The resonsible(s) for this tournament (person, club, company, ...)
        /// </summary>
        public string Organisator { get; set; }

        /// <summary>
        /// Matches that belong to this tournament
        /// </summary>
        public List<Match> MatchList { get; set; }


        /// <summary>
        /// Converts the object to a DTO object
        /// </summary>
        /// <returns></returns>
        public DtoTournament ToDto()
        {
            return new DtoTournament()
            {
                Id = Id,
                City = City,
                Date = Date,
                Location = Location,
                MatchIdList = MatchList == null ? null : MatchList.Select(x => x.Id).ToArray(),
                Name = Name,
                Organisator = Organisator
            };
        }

        /// <summary>
        /// Converts the object from a DTO object
        /// </summary>
        /// <param name="dto"></param>
        public void FromDto(DtoTournament dto)
        {
            Id = dto.Id;
            City = dto.City;
            Date = dto.Date ?? DateTime.Now;
            Location = dto.Location;
            Name = dto.Name;
            Organisator = dto.Organisator;

            if (MatchList != null)
                MatchList.Clear();

            if (MatchList == null)
                MatchList = new List<Match>();

            foreach (var aMatch in dto.MatchIdList)
                MatchList.Add(new Match() { Id = aMatch });
        }
    }
}
