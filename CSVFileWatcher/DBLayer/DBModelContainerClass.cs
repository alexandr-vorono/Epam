using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public partial class DBModelContainer
    {
        /// <summary>
        /// Добавление названия нового файла в БД
        /// </summary>
        /// <param name="fileName">Название файла</param>
        public void AddFileName(string fileName)
        {
            this.HistoeyFilesSet.Add(new HistoeyFiles() { FileName = fileName });
            this.SaveChanges();
        }
        /// <summary>
        /// Поиск файла в БД
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <returns></returns>
        public bool CheckFileName(string fileName)
        {
            return this.HistoeyFilesSet.Any(x => x.FileName == fileName);
        }
        /// <summary>
        /// Добавление заказа в БД
        /// </summary>
        /// <param name="orders">Заказ</param>
        public void AddOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                this.OrderSet.Add(order);
            }
            this.SaveChanges();
        }
    }
}
