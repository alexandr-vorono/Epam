using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Call
    {
        public Client FromClient { get; set; }
        public Client ToClient { get; set; }
        public DateTime StartingCallTime { get; set; }
        public DateTime StartCallTime { get; set; }
        public DateTime EndCallTime { get; set; }


        public void StartCall()
        {
            StartCallTime = DateTime.Now;
        }

        public void EndCall()
        {
            EndCallTime = DateTime.Now.AddMinutes(2);
        } 
    }
}
