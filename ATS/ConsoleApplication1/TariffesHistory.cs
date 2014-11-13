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
    }
}
