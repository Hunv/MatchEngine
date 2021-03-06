﻿using MatchLibrary.ApiModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.DatabaseModel
{
    public class Match
    {
        /// <summary>
        /// The ID of the match
        /// </summary>
        [Key]
        public int Id { get; set; }

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
        /// Converts the object to a DTO object
        /// </summary>
        /// <returns></returns>
        public DtoMatch ToDto()
        {
            return new DtoMatch()
            {
                Id = Id,
                ScoreTeam1 = ScoreTeam1,
                ScoreTeam2 = ScoreTeam2,
                NameTeam1 = NameTeam1,
                NameTeam2 = NameTeam2,
                TimeLeftSeconds = TimeLeftSeconds
            };
        }

        public void FromDto(DtoMatch dto)
        {
            Id = dto.Id;
            ScoreTeam1 = dto.ScoreTeam1 ?? 0;
            ScoreTeam2 = dto.ScoreTeam2 ?? 0;
            NameTeam1 = dto.NameTeam1;
            NameTeam2 = dto.NameTeam2;
            TimeLeftSeconds = dto.TimeLeftSeconds ?? 0;
        }

    }
}
