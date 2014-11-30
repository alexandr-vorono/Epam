using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public partial class Order
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="time">Дата</param>
        /// <param name="managerId">ID менеджера</param>
        /// <param name="clientId">ID клиента</param>
        /// <param name="goodsId">ID товара</param>
        /// <param name="amount">Сумма заказа</param>
        public Order(DateTime time, int managerId, int clientId, int goodsId, int amount)
        {
            this.Time = time;
            this.ManagerId = managerId;
            this.ClientId = clientId;
            this.GoodsId = goodsId;
            this.Amount = amount;
        }
    }
}
