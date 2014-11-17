using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Contract
    {
        public DateTime StartDate { get; set; }
        public TariffesHistory TariffHistory { get; set; }
        public DateTime LastChangeTime { get; set; }

        public Contract()
        {
            StartDate = Program.myTimer.GetTime();
            LastChangeTime = StartDate;
        }
    }
}
