using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class TariffesHistory
    {
        //Список тарифов
        private List<Tariff> tariffes = new List<Tariff>();
        /// <summary>
        /// Клнструктор с параметрами
        /// </summary>
        /// <param name="tariff">Тариф</param>
        public TariffesHistory(Tariff tariff)
        {
            tariffes.Add(tariff);
        }
        /// <summary>
        /// Возвращает  тариф деюствующий на данный момент
        /// </summary>
        /// <param name="date">Настоящее время</param>
        /// <returns>Тариф</returns>
        public Tariff GetTariffByDate(DateTime date)
        {
            return tariffes.Last(x => x.CreationDate <= date);
        }
        /// <summary>
        /// Добавляет тариф, если прошел месяц с даты подключения последнего
        /// </summary>
        /// <param name="tariff">Тариф</param>
        /// <returns></returns>
        public bool AddTariff(Tariff tariff)
        {
            if (tariffes.Last().CreationDate.AddMonths(1) < tariff.CreationDate)
            {
                tariffes.Add(tariff);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Метод возвращает массив тарифных планов абонента.
        /// </summary>
        /// <returns>Массив тарифных планов.</returns>
        public List<Tariff> GetAllTariffes()
        {
            return tariffes;
        }
    }
}
