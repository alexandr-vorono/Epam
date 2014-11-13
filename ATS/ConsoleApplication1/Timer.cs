using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Timer
    {
        private DateTime time;
        private int minTic;
        private int maxTic;
        private Random rnd;

        public Timer(DateTime startTime, int minTic, int maxTic)
        {
            this.time = startTime;
            this.minTic = minTic;
            this.maxTic = maxTic;
            rnd = new Random();
        }

        public DateTime GetTime()
        {
            return time;
        }

        public DateTime GetNextTime()
        {
            return time = time.AddSeconds(rnd.Next(minTic, maxTic));
        }
    }
}
