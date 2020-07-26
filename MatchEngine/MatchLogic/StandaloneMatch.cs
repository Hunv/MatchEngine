using MatchEngine.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace MatchEngine.MatchLogic
{
    public static class StandaloneMatch
    {
        private static Timer tmrMatchtimer = new Timer(50);
        private static DateTime? ReferenceSystemTime;
        private static int ReferenceSeconds = 0;
        private static bool IsInitialized = false;
        

        private static void TmrMatchtimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (ReferenceSystemTime == null)
                return;
                        
            if (ReferenceSeconds != DateTime.Now.Second)
            {
                var diff = DateTime.Now.Second - ReferenceSeconds;
                if (diff < 0)
                    diff += 60;
                ReferenceSeconds = DateTime.Now.Second;

                //Decrease SecondsLeft
                using (var dbContext = new MyDbContext())
                {
                    var secondsLeft = dbContext.StandaloneMatch.First().SecondsLeft;
                    dbContext.StandaloneMatch.First().SecondsLeft = secondsLeft - diff;
                    dbContext.SaveChanges();

                    if (dbContext.StandaloneMatch.First().SecondsLeft <= 0)
                    {
                        Stop();
                    }
                }
            }
        }

        public static void Start()
        {
            if (!IsInitialized)
            {
                tmrMatchtimer.Elapsed += TmrMatchtimer_Elapsed;
                IsInitialized = true;
            }
            
            ReferenceSystemTime = DateTime.Now;
            ReferenceSeconds = 0;
            tmrMatchtimer.Start();
        }

        public static void Stop()
        {            
            tmrMatchtimer.Stop();
            ReferenceSystemTime = null;
        }
    }
}
