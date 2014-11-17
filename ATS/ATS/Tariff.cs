using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Tariff
    {
        //Название тарифа
        public string Name { get; set; }
        //Стоимость  минуты
        public int MinuteCost { get; set; }
        //Абонентская плата
        public int MonthCost { get; set; }
        //Время подключения тарианого  плана
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="minuteCost">Стоимость  минуты</param>
        /// <param name="monthCost">Абонентская плата</param>
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
