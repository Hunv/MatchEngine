using MatchLibrary.ApiModel;
using MatchLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.DatabaseModel
{
    public class Match
    {
        public Match() { }
        public Match(DtoMatch dtoMatch)
        {
            FromDto(dtoMatch);
        }

        /// <summary>
        /// The ID of the match
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Id of team 1 if a created team is used
        /// </summary>
        public int Team1Id { get; set; }

        /// <summary>
        /// The Id of team 2 if a created team is used
        /// </summary>
        public int Team2Id { get; set; }

        /// <summary>
        /// Scores of Team1
        /// </summary>
        [Required]
        public int ScoreTeam1 { get; set;}

        /// <summary>
        /// Scores of Team2
        /// </summary>
        [Required]
        public int ScoreTeam2 { get; set; }

        /// <summary>
        /// Name of Team1
        /// </summary>
        [Required]
        public string NameTeam1 { get; set; }

        /// <summary>
        /// Name of Team2
        /// </summary>
        [Required]
        public string NameTeam2 { get; set; }

        /// <summary>
        /// Time left
        /// </summary>
        [Required]
        public int TimeLeftSeconds { get; set; }

        /// <summary>
        /// The tournament this match belongs to
        /// </summary>
        public Tournament Tournament { get; set; }

        /// <summary>
        /// The Status of the Match
        /// </summary>
        public int MatchStatus { get; set; }

        /// <summary>
        /// Converts the object to a DTO object
        /// </summary>
        /// <returns></returns>
        public DtoMatch ToDto()
        {
            var dto = new DtoMatch()
            {
                Id = Id,
                ScoreTeam1 = ScoreTeam1,
                ScoreTeam2 = ScoreTeam2,
                NameTeam1 = NameTeam1,
                NameTeam2 = NameTeam2,
                TimeLeftSeconds = TimeLeftSeconds,
                MatchStatus = MatchStatus,
                Team1Id = Team1Id,
                Team2Id = Team2Id
            };

            if (Tournament != null)
                dto.TournamentId = Tournament.Id;

            return dto;
        }

        /// <summary>
        /// Converts the object from a DTO object
        /// </summary>
        /// <param name="dto"></param>
        public void FromDto(DtoMatch dto)
        {
            Id = dto.Id;
            ScoreTeam1 = dto.ScoreTeam1 ?? 0;
            ScoreTeam2 = dto.ScoreTeam2 ?? 0;
            NameTeam1 = dto.NameTeam1;
            NameTeam2 = dto.NameTeam2;
            TimeLeftSeconds = dto.TimeLeftSeconds ?? 0;
            Tournament = dto.TournamentId.HasValue ? new Tournament() { Id = dto.TournamentId.Value }  : null;
            MatchStatus = dto.MatchStatus;
            Team1Id = dto.Team1Id ?? 0;
            Team2Id = dto.Team2Id ?? 0;
        }

    }
}
