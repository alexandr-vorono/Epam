using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Tariff
    {
        public string Name { get; set; }
        public int MinuteCost { get; set; }
        public int MonthCost { get; set; }
        public DateTime CreationDate { get; set; }

        public Tariff(string name, int minuteCost, int monthCost)
        {
            CreationDate = Program.myTimer.GetTime();
            this.Name = name;
            this.MinuteCost = minuteCost;
            this.MonthCost = monthCost;
        }
        /// <summary>
        /// Метод возвращает стоимость дня изходя из абонентской платы.
        /// </summary>
        /// <param name="daysInMonth">Количество дней в месяце.</param>
        /// <returns>Стоимость дня.</returns>
        public virtual double DayCost(int daysInMonth)
        {
            return (double)MonthCost / daysInMonth;
        }
    }
}
