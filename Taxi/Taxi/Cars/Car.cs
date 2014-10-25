using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public abstract class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Price { get; set; }
        /// <summary>
        /// Конструктор по  умолчанию
        /// </summary>
        protected Car() { }
        /// <summary>
        /// Конструктор  с параметрами
        /// </summary>
        /// <param name="make">Марка</param>
        /// <param name="model">Модель</param>
        /// <param name="speed">Максимальная скорость</param>
        /// <param name="price">Цена</param>
        protected Car(string make, string model, int speed, int price)
        {
            this.Make = make;
            this.Model = model;
            this.Speed = speed;
            this.Price = price;
        }

        protected String Info()
        {
           // string.Format("\nНазвание: {0}", this.Make);
            return "\nНазвание:" + this.Make.ToString() + "\nМодель:" + this.Model.ToString() +
                "\nМаксимальная скорость:" + this.Speed.ToString() + "\nЦена:" + this.Price.ToString();
        }
    }
}
