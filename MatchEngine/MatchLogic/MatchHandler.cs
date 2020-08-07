using MatchEngine.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace MatchEngine.MatchLogic
{
    public class MatchHandler
    {
        private Timer tmrMatchtimer = new Timer(50);
        private DateTime? ReferenceSystemTime;
        private int ReferenceSecond = 0;
        private bool IsInitialized = false;
        public int MatchId { get; set; }
        public MatchHandler(int matchId)
        {
            MatchId = matchId;
        }

        private void TmrMatchtimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //If not initialized, cancel
            if (ReferenceSystemTime == null)
                return;
                        
            //If a second of over
            if (ReferenceSecond != DateTime.Now.Second)
            {
                //Get the difference of the seconds. In case of high load or hickup, it may be more than one
                var diff = DateTime.Now.Second - ReferenceSecond;
                if (diff < 0)
                    diff += 60;

                //Set the new reference value
                ReferenceSecond = DateTime.Now.Second;

                //Decrease SecondsLeft
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Matches.Single(x => x.Id == MatchId).TimeLeftSeconds -= diff;                    
                    dbContext.SaveChanges();

                    if (dbContext.Matches.Single(x => x.Id == MatchId).TimeLeftSeconds <= 0)
                    {
                        Stop();
                    }
                }
            }
        }

        public void Start()
        {
            if (!IsInitialized)
            {
                tmrMatchtimer.Elapsed += TmrMatchtimer_Elapsed;
                IsInitialized = true;
            }
            
            ReferenceSystemTime = DateTime.Now;
            ReferenceSecond = DateTime.Now.Second == 0 ? 59 : DateTime.Now.Second -1;
            tmrMatchtimer.Start();
        }

        public void Stop()
        {            
            tmrMatchtimer.Stop();
            ReferenceSystemTime = null;
        }
    }
}
