using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class PassengerCar : Car
    {
        public double EngineVolume { get; set; }

        public PassengerCar() : base() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="make">Марка</param>
        /// <param name="model">Модель</param>
        /// <param name="speed">Максимальная скорость</param>
        /// <param name="price">Цена</param>
        /// <param name="engineVolume">Объем двигателя</param>
        public PassengerCar(string make, string model, int speed, int price, double engineVolume) :
            base(make, model, speed, price)
        {
            this.EngineVolume = engineVolume;
        }
        public override String ToString()
        {
            return "Легковой:" + Info() + "\nОбъем:" + this.EngineVolume.ToString() + "\n";
        }

    }
}
