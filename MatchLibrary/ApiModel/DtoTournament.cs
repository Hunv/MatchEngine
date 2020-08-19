using System;
using System.Collections.Generic;
using System.Text;

namespace MatchLibrary.ApiModel
{
    public class DtoTournament
    {
        /// <summary>
        /// Internal Id for a tournament
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Tournament
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Date of the tournament
        /// </summary>
        public DateTime? Date { get; set; }

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
        //public List<DtoMatch> MatchList { get; set; }
        public int[] MatchIdList { get; set; }
    }
}
