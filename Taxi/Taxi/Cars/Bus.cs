using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class Bus : Car
    {
        public int Count { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Bus() : base() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="make">Марка</param>
        /// <param name="model">Модель</param>
        /// <param name="speed">Максимальная скорость</param>
        /// <param name="price">Цена</param>
        /// <param name="count">Количество мест</param>
        public Bus(string make, string model, int speed, int price, int count) :
            base(make, model, speed, price)
        {
            this.Count = count;
        }
        public override String ToString()
        {
            return "Автобус:" + Info() + "\nКоличество пассажиров:" + this.Count.ToString() + "\n";
        }
    }
}
