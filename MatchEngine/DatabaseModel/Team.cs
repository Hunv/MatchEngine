using MatchLibrary.ApiModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.DatabaseModel
{
    public class Team
    {
        public Team() { }
        public Team(DtoTeam dtoTeam)
        {
            FromDto(dtoTeam);
        }

        /// <summary>
        /// The ID of the team
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Team
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// A short version of the Teamname
        /// </summary>
        [Required]
        public string Shortname { get; set; }
        
        /// <summary>
        /// A shortcut for the teamname
        /// </summary>
        [Required]
        public string Shortcut { get; set; }

        /// <summary>
        /// The name of the teamcaptain
        /// </summary>
        [Required]
        public string Teamcaptain { get; set; }
        
        /// <summary>
        /// The name of the vice teamcaptain
        /// </summary>
        public string ViceTeamcaptain { get; set; }
        
        /// <summary>
        /// The name of the coach
        /// </summary>
        public string Coach { get; set; }
                
        /// <summary>
        /// The name of the club
        /// </summary>
        public string Club { get; set; }

        /// <summary>
        /// Notes regarding this team
        /// </summary>        
        public string Notes { get; set; }

        /// <summary>
        /// List of tournaments where this team is participating
        /// </summary>
        public List<Team2Tournament> TournamentList { get; set; }

        /// <summary>
        /// List of matches where this team is participating
        /// </summary>
        public List<Team2Match> MatchList { get; set; }


        /// <summary>
        /// Converts the object to a DTO object
        /// </summary>
        /// <returns></returns>
        public DtoTeam ToDto()
        {
            var dto = new DtoTeam()
            {
                Id = Id,
                Club = Club,
                Coach = Coach,
                Name = Name,
                Notes = Notes,
                Shortcut = Shortcut,
                Shortname = Shortname,
                Teamcaptain = Teamcaptain,
                ViceTeamcaptain = ViceTeamcaptain
            };

            if (MatchList != null)
                dto.MatchIdList = MatchList.Select(x => x.MatchId).ToList();

            if (TournamentList != null)
                dto.TournamentIdList = TournamentList.Select(x => x.TournamentId).ToList();

            return dto;
        }

        /// <summary>
        /// Converts the object from a DTO object
        /// </summary>
        /// <param name="dto"></param>
        public void FromDto(DtoTeam dto)
        {
            Id = dto.Id;
            Club = dto.Club;
            Coach = dto.Coach;
            Name = dto.Name;
            Notes = dto.Notes;
            Shortcut = dto.Shortcut;
            Shortname = dto.Shortname;
            Teamcaptain = dto.Teamcaptain;
            ViceTeamcaptain = dto.ViceTeamcaptain;

            MatchList = dto.MatchIdList == null ? null : dto.MatchIdList.Select(x => new Team2Match() { MatchId = x, Team = this}).ToList();
            TournamentList = dto.TournamentIdList == null ? null : dto.TournamentIdList.Select(x => new Team2Tournament() { TournamentId = x, Team = this }).ToList();
        }
    }
}
