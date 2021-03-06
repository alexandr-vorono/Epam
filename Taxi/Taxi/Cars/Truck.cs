﻿using System;

namespace Taxi.Cars
{
    public class Truck : Car
    {
        public int Load { get; set; }

        public Truck() : base() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="make">Марка</param>
        /// <param name="model">Модель</param>
        /// <param name="speed">Максимальная скорость</param>
        /// <param name="price">Цена</param>
        /// <param name="load">Грузоподъемность</param>
        public Truck(string make, string model, int speed, int price, int load) :
            base(make, model, speed, price)
        {
            this.Load = load;
        }
        public override String ToString()
        {
            return "Грузовой:" + Info() + "\n" + "Грузоподъёмность:" + Load + "\n";
        }
    }
}
