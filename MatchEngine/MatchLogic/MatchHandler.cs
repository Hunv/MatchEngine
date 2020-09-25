using MatchEngine.DatabaseModel;
using MatchLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace MatchEngine.MatchLogic
{
    public class MatchHandler
    {
        private Timer tmrMatchtimer = new Timer(SystemSettings.MatchHandlerRefreshTime);
        private Timer tmrDisposeTimer = new Timer(SystemSettings.MatchHandlerDisposeTime); //To dispose this Handler 10 Minutes after game finished
        private DateTime? ReferenceSystemTime;
        private int ReferenceSecond = 0;
        private bool IsInitialized = false;
        private EnumMatchStatus MatchStatus = EnumMatchStatus.Unknown;
        public int MatchId { get; set; }
        public MatchHandler(int matchId)
        {
            MatchId = matchId;
            MatchStatus = EnumMatchStatus.Upcomming;
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
                    if (dbContext.Matches.Single(x => x.Id == MatchId).TimeLeftSeconds <= 0)
                    {
                        Stop();
                    }
                    else
                    {
                        dbContext.Matches.Single(x => x.Id == MatchId).TimeLeftSeconds -= diff;
                        Console.WriteLine("{2} Timeleft: {0}, (-{1}) ", dbContext.Matches.Single(x => x.Id == MatchId).TimeLeftSeconds, diff, MatchId);
                        dbContext.SaveChanges();
                    }
                }
            }
        }

        public void Start()
        {
            if (!IsInitialized)
            {
                tmrMatchtimer.Elapsed += TmrMatchtimer_Elapsed;
                tmrDisposeTimer.Elapsed += TmrDisposetimer_Elapsed;
                IsInitialized = true;
            }
            
            ReferenceSystemTime = DateTime.Now;
            ReferenceSecond = DateTime.Now.Second == 0 ? 59 : DateTime.Now.Second -1;
            tmrMatchtimer.Start();
            MatchStatus = EnumMatchStatus.Running;
        }

        public void Stop()
        {            
            tmrMatchtimer.Stop();
            ReferenceSystemTime = null;
        }

        /// <summary>
        /// The game ended and the scores are fixed. Time is not running anymore and no overtime, penalty shots etc. are left.
        /// </summary>
        public void Finish()
        {
            tmrMatchtimer.Stop();
            ReferenceSystemTime = null;
            MatchStatus = EnumMatchStatus.Ended;
            tmrDisposeTimer.Start();
        }


        /// <summary>
        /// Cleanup this Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrDisposetimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MatchStatus = EnumMatchStatus.Finished;
            OnDisposeMatchhandler(new EventArgs());
        }

        public event EventHandler<EventArgs> DisposeMatchHandler;
        protected virtual void OnDisposeMatchhandler(EventArgs e)
        {
            EventHandler<EventArgs> handler = DisposeMatchHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
