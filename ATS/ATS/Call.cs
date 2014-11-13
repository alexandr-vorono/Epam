using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Call
    {
        public Client FromClient { get; set; }
        public Client ToClient { get; set; }
        public DateTime StartCallTime { get; set; }
        public DateTime StartTalkTime { get; set; }
        public DateTime EndCallTime { get; set; }
        public CallResult CallResult { get; set; }
        public bool IsStartTalk { get; set; }
        public bool IsEndCall { get; set; }

        public Call()
        {
            StartCallTime = Program.myTimer.GetTime();
            IsStartTalk = false;
            IsEndCall = false;
        }

        public void StartTalk()
        {
            StartTalkTime = Program.myTimer.GetTime();
            IsStartTalk = true;
        }

        public void EndCall()
        {
            CallResult = CallResult.Success;
            EndCallTime = Program.myTimer.GetTime();
            IsEndCall = true;
        }

        public int TalkDuration()
        {
            return (int)Math.Ceiling((EndCallTime - StartTalkTime).TotalMinutes);
        }

        public void FailCall(CallResult callResult)
        {
            this.CallResult = callResult;
            IsEndCall = true;
            EndCallTime = StartCallTime;
            StartTalkTime = StartCallTime;
        }
    }
}
