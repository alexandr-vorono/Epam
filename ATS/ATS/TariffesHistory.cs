using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class TariffesHistory
    {
        private List<Tariff> tariffes = new List<Tariff>();
        public TariffesHistory(Tariff tariff)
        {
            tariffes.Add(tariff);
        }
        public Tariff GetTariffByDate(DateTime date)
        {
            return tariffes.Last(x => x.CreationDate <= date);
        }
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
        /// Метод возвращает текущий тарифный план.
        /// </summary>
        /// <returns>Тарифный план.</returns>
        public Tariff GetCurrentTariff()
        {
            return tariffes.Last();
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
