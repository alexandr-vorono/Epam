using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DBLayer;

namespace CSVFileWatcher
{
    class Parser
    {

        /// <summary>
        /// Метод парсит строки файла
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <returns>Заказ</returns>
        public List<Order> ParseList(string fileName)
        {
            List<Order> order = new List<Order>();
            DateTime time;
            int managerId,
                clientId,
                goodsId,
                amount;
            if (!int.TryParse(Path.GetFileName(fileName).Split('_')[0], out managerId))
                throw new InvalidDataException("ManagerId is not int");

            foreach (var s in File.ReadAllLines(fileName))
            {
                var parametres = s.Split(';');

                if (!DateTime.TryParse(parametres[0], out time))
                    throw new InvalidDataException("Time is not DateTime");

                if (!int.TryParse(parametres[1], out clientId))
                    throw new InvalidDataException("ClientId is not int");

                if (!int.TryParse(parametres[2], out goodsId))
                    throw new InvalidDataException("GoodsId is not int");

                if (!int.TryParse(parametres[3], out amount))
                    throw new InvalidDataException("Amount is not double");

                order.Add(new Order(time, managerId, clientId, goodsId,  amount));
            }

            return order;
        }
    
    }
}
