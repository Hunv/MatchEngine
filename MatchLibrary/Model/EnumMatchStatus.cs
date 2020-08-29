using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchLibrary.Model
{
    public enum EnumMatchStatus
    {
        Unknown = 0, 
        Draft = 1, //The match is not fully planned
        Planned = 10, //The match was created
        Upcomming = 11, //The match is loaded
        Running = 20, //The match is ongoing
        Ended = 50, //The time is over
        Finished = 51 //The match is done. Everything is fixed.
    }
}
