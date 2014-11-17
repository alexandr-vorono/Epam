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
        //Начало  действия договора
        public DateTime StartDate { get; set; }
        //История изменения тарифного  плана
        public TariffesHistory TariffHistory { get; set; }
        //Последнее изменение тарифного  плана
        public DateTime LastChangeTime { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Contract()
        {
            StartDate = Program.myTimer.GetTime();
            LastChangeTime = StartDate;
        }
    }
}
